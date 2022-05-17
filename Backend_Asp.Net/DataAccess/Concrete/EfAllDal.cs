using Microsoft.EntityFrameworkCore;
using server.DataAccess.Abstract;
using server.Entities.Concrete;
using server.Entities.DTOs;

namespace server.DataAccess.Concrete
{
    public class EfAllDal : IAllDal
    {
        public DersYoklaması DersiAlan(int DersSaat_id)
        {
            DersYoklaması result = new DersYoklaması();
            using(BitirmeContext _bitirmeContext = new BitirmeContext())
            {
                var dersSaat = _bitirmeContext.tbl_DersSaat.SingleOrDefault(x => x.id == DersSaat_id);
                var dersiAlanlar = _bitirmeContext.tbl_AlınanDers.Where(x => x.Ders_Id == dersSaat.Ders_Id).ToList();
                var derseGirenler = _bitirmeContext.tbl_Yoklama.Where(x => x.DersSaat_Id == DersSaat_id && x.Durum != false).ToList();

                List<AlınanDers> derseGirmeyenler = new List<AlınanDers>();
                foreach (var alan in dersiAlanlar)
                {
                    int count = 0;
                    foreach (var giren in derseGirenler)
                    {
                        if(alan.Ogrenci_Id == giren.Ogrenci_Id)
                        {
                            count++;
                            break;
                            //derse girmiş oluyor.
                        }
                    }
                    if(count == 0)
                    {
                        derseGirmeyenler.Add(alan);
                    }
                }
                //elimizde dersi alanlar, derse girenler ve derse girmeyenler var.

                List<YoklamaDto> GirenlerYoklamaDto = new List<YoklamaDto>();
                YoklamaDto yoklama;
                //derse girenleri yoklamaDto formatına getiriyim.
                foreach (var item in derseGirenler)
                {
                    yoklama = new YoklamaDto();
                    var ogrenci = _bitirmeContext.tbl_Ogrenci.SingleOrDefault(x => x.id == item.Ogrenci_Id);
                    yoklama.OgrenciAd = ogrenci.Ogrenci_Adi;
                    yoklama.OgrenciSoyad = ogrenci.Ogrenci_Soyadi;
                    yoklama.YoklamaId = item.id;
                    yoklama.OgrenciId = ogrenci.id;

                    GirenlerYoklamaDto.Add(yoklama);
                }

                List<YoklamaDto> GirmeyenlerYoklamaDto = new List<YoklamaDto>();
                
                if(derseGirmeyenler.Count() == dersiAlanlar.Count())
                {
                    foreach(var item in derseGirmeyenler)
                    {
                        yoklama = new YoklamaDto();
                        var ogrenci = _bitirmeContext.tbl_Ogrenci.SingleOrDefault(x => x.id == item.Ogrenci_Id);
                        yoklama.OgrenciAd = ogrenci.Ogrenci_Adi;
                        yoklama.OgrenciSoyad = ogrenci.Ogrenci_Soyadi;
                        yoklama.OgrenciId = ogrenci.id;
                    }
                }
                //derse girmeyenleri yoklamaDto formatına çevir.
                foreach (var item in derseGirmeyenler)
                {
                    yoklama = new YoklamaDto();
                    var ogrenci = _bitirmeContext.tbl_Ogrenci.SingleOrDefault(x => x.id == item.Ogrenci_Id);
                    yoklama.OgrenciAd = ogrenci.Ogrenci_Adi;
                    yoklama.OgrenciSoyad = ogrenci.Ogrenci_Soyadi;
                    yoklama.OgrenciId = ogrenci.id;
                    if(derseGirmeyenler.Count() != dersiAlanlar.Count())
                    {
                        var yokla = _bitirmeContext.tbl_Yoklama.SingleOrDefault(x => x.Ogrenci_Id == ogrenci.id && x.DersSaat_Id == DersSaat_id);
                        yoklama.YoklamaId = yokla.id;
                    }
                    GirmeyenlerYoklamaDto.Add(yoklama);
                }
                //sonradan bütün dersi alanlar gelsin diye yaptım.
                var dersiAlanlar2 = _bitirmeContext.tbl_AlınanDers.Where(x => x.Ders_Id == dersSaat.Ders_Id).ToList();
                result.DersiAlanlar = dersiAlanlar2;
                result.DerseGelenler = GirenlerYoklamaDto;
                result.DerseGelmeyenler = GirmeyenlerYoklamaDto;
                return result;
            }
        }

        public List<BildirimDto> GetsBildirim(int id, bool? ogrenci, bool admin)
        {
            //bildirimler gelicek.
            using (BitirmeContext _bitirmeContext = new BitirmeContext())
            {
                List<BildirimDto> _bildirim = new List<BildirimDto>();
                BildirimDto bildirimDto;
                var bildirim = _bitirmeContext.tbl_Bildirim.Where(x => x.Durum == true).ToList();
                if (bildirim.Count != 0)
                {
                    DateTime tarih = DateTime.Now;
                    foreach (var item in bildirim)
                    {
                        bildirimDto = new BildirimDto();
                        var dersSaat = _bitirmeContext.tbl_DersSaat.SingleOrDefault(x => x.id == item.DersSaat_Id);
                        if (tarih > dersSaat.Tarih)     //bildirimdeki derssaat id kısmından dersSaatine erişiyor saatine bakıyor.
                        {
                            item.Durum = false;
                            _bitirmeContext.SaveChanges();
                        }

                        if (item.Durum != false) 
                        {
                            //var dersSaat = _bitirmeContext.tbl_DersSaat.SingleOrDefault(x => x.id == item.DersSaat_Id && x.Durum == true && x.Iptal != true);
                            if (dersSaat != null)
                            {
                                var ders = _bitirmeContext.tbl_Ders.SingleOrDefault(x => x.id == dersSaat.Ders_Id);
                                int alınanDers = 0;

                                if(admin != true) //admin değil ise girsin
                                {
                                    if (ogrenci == true)
                                    {
                                        //öğrenci: şuan olan bildirimdeki dersi almışmı bakılıyor almamış ise = 0 
                                        alınanDers = _bitirmeContext.tbl_AlınanDers.Count(x => x.Ogrenci_Id == id && x.Ders_Id == ders.id);
                                    }
                                    else
                                    {
                                        //öğretmen: dersi veriyormu diye bakılıyor.
                                        if (ders.Ogretmen_Id == id)
                                        {
                                            alınanDers++;
                                        }
                                    }
                                }
                                

                                //eğer öğrenci veya öğretmene tanımlı ise gidiyor admin direk giriyor.
                                if (alınanDers > 0 || admin == true)
                                {
                                    bildirimDto.Ders_Kodu = ders.Ders_Kodu;
                                    bildirimDto.Baslik = _bitirmeContext.tbl_BildirimKonu.SingleOrDefault(x => x.id == item.BildirimKonu_Id).Bildirim_Konu;
                                    bildirimDto.OlusturulduguTarih = item.Olusturuldugu_Tarih;
                                    bildirimDto.Ders_Adi = ders.Ders_Adi;
                                    bildirimDto.dersSaati = dersSaat.Tarih;
                                    if (item.YeniSaat != null)
                                    {
                                        bildirimDto.YeniSaati = item.YeniSaat;
                                    }
                                    if (item.YeniSinif_Id != null)
                                    {
                                        bildirimDto.YeniSinifi = _bitirmeContext.tbl_Sinif.SingleOrDefault(x => x.id == item.YeniSinif_Id).Sinif_Adi; ;
                                    }
                                    _bildirim.Add(bildirimDto);
                                }
                            }
                        }
                        
                    }
                }
                return _bildirim;
            }
        }

        public List<YoklamaDto> GetsYoklama(int Ders_saatId)
        {
            List<YoklamaDto> _yoklama = new List<YoklamaDto>();
            using (BitirmeContext _bitirmeContext = new BitirmeContext())
            {
                YoklamaDto yoklamaDto;
                var yoklama = _bitirmeContext.tbl_Yoklama.Where(x => x.DersSaat_Id == Ders_saatId && x.Durum == true).ToList();
                foreach (var item in yoklama)
                {
                    yoklamaDto = new YoklamaDto();
                    yoklamaDto.YoklamaId = item.id;
                    var ogrenci = _bitirmeContext.tbl_Ogrenci.SingleOrDefault(x => x.id == item.Ogrenci_Id);
                    if (ogrenci == null)
                    {
                        break;
                    }
                    yoklamaDto.OgrenciAd = ogrenci.Ogrenci_Adi;
                    yoklamaDto.OgrenciSoyad = ogrenci.Ogrenci_Soyadi;
                    _yoklama.Add(yoklamaDto);
                }
                return _yoklama;
            }
        }

        public AuthDto Giris(string KullaniciAdi, string Sifre)
        {
            AuthDto member = new AuthDto();
            using (BitirmeContext _bitirmeContext = new BitirmeContext())
            {
                var ogrenci = _bitirmeContext.tbl_Ogrenci.SingleOrDefault(x => x.Ogrenci_Tc == KullaniciAdi && x.Durum != false && x.Ogrenci_Sifre == Sifre);
                if (ogrenci != null)
                {
                    member.Türü = 1;
                    member.Id = ogrenci.id;
                    return member;
                }
                var ogretmen = _bitirmeContext.tbl_Ogretmen.SingleOrDefault(x => x.Ogretmen_Tc == KullaniciAdi && x.Durum != false && x.Ogretmen_Sifre == Sifre);
                if (ogretmen != null)
                {
                    member.Türü = 2;
                    member.Id = ogretmen.id;
                    return member;
                }
                var admin = _bitirmeContext.tbl_Admin.SingleOrDefault(x => x.Admin_KullanıcıAdi == KullaniciAdi && x.Admin_Sifre == Sifre);
                if (admin != null)
                {
                    member.Türü = 3;
                    member.Id = admin.id;
                    return member;
                }
                return null;
            }
        }

        public List<YoklamaForAll> yoklamaForAlls(int ders_Id, bool? Ogrenci, int? ogrenci_Id)
        {
            //ders id geliyor dersSaat tablosunda dersler alınıyor tabi false olanlar.
            List<YoklamaForAll> yoklamaFor = new List<YoklamaForAll>();
            using (BitirmeContext _bitirmeContext = new BitirmeContext())
            {
                YoklamaForAll yoklamaForAll;
                var butunDers = _bitirmeContext.tbl_DersSaat.Where(x => x.Ders_Id == ders_Id && x.Durum == true && x.Iptal != true).OrderBy(x => x.Tarih).ToList();
                if(butunDers.Count != 0)
                {
                    foreach (var item in butunDers)
                    {
                        if(item.Tarih < DateTime.Now)
                        {
                            item.Durum = false;
                            _bitirmeContext.SaveChanges();
                        }
                    }
                }

                var ders = _bitirmeContext.tbl_DersSaat.Where(x => x.Ders_Id == ders_Id && x.Durum == false && x.Iptal != true).ToList();
                foreach (var item in ders)
                {
                    yoklamaForAll = new YoklamaForAll();
                    yoklamaForAll.YapildigiTarih = item.Tarih;
                    yoklamaForAll.DersSaat_Id = item.id;
                    yoklamaForAll.KatilanOgrenci = _bitirmeContext.tbl_Yoklama.Count(x => x.DersSaat_Id == item.id && x.Durum == true);

                    if (Ogrenci == true)
                    {
                        var yoklama = _bitirmeContext.tbl_Yoklama.Count(x => x.DersSaat_Id == item.id && x.Ogrenci_Id == ogrenci_Id && x.Durum == true);
                        if (yoklama != 0)
                            yoklamaForAll.OgrenciYoklamaKontrol = true;
                    }

                    yoklamaFor.Add(yoklamaForAll);
                }
            }
            return yoklamaFor;
        }
    }
}
