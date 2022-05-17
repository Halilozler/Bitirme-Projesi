using server.Entities.Concrete;
using server.DataAccess.Abstract;
using server.Entities.DTOs;

namespace server.DataAccess.Concrete
{
    public class EfOgretmenDal : EfAllDal, IOgretmenDal
    {
        public List<GelecekForAll> DerseGoreGelecekGetir(int dersId)
        {
            List<GelecekForAll> gelecekList = new List<GelecekForAll>();
            using (BitirmeContext _bitirmeContext=new BitirmeContext())
            {
                var dersler = _bitirmeContext.tbl_DersSaat.Where(x => x.Ders_Id == dersId && x.Durum != false && x.Iptal != true).ToList();
                GelecekForAll gelecek;
                foreach (var item in dersler)
                {
                    gelecek = new GelecekForAll();
                    gelecek.Tarih = item.Tarih;
                    gelecek.DersSaat_id = item.id;
                    gelecekList.Add(gelecek);
                }
                return gelecekList;
            }
        }

        public void DersIptal(int DersSaatId)
        {
            using (BitirmeContext _bitirmeContext = new BitirmeContext())
            {
                var ders = _bitirmeContext.tbl_DersSaat.SingleOrDefault(x => x.id == DersSaatId);
                ders.Iptal = true;
                ders.Durum = false;

                var b = _bitirmeContext.tbl_Bildirim.SingleOrDefault(x => x.BildirimKonu_Id == 2 && x.DersSaat_Id == DersSaatId);
                if(b == null)
                {
                    Bildirim bildirim = new Bildirim();
                    bildirim.BildirimKonu_Id = 2;
                    bildirim.DersSaat_Id = DersSaatId;
                    bildirim.Durum = true;
                    bildirim.Olusturuldugu_Tarih = DateTime.Now;
                    _bitirmeContext.Add(bildirim);
                }
                _bitirmeContext.SaveChanges();
            }
        }

        public List<GelecekForAll> GelecekDersGetir(int id)
        {
            List<GelecekForAll> ListGelecekDers = new List<GelecekForAll>();
            using (BitirmeContext _bitirmeContext = new BitirmeContext())
            {
                GelecekForAll ogretmen;
                var dersler = _bitirmeContext.tbl_Ders.Where(x => x.Ogretmen_Id == id).ToList();
                foreach (var item in dersler)
                {
                    var result = _bitirmeContext.tbl_DersSaat.Where(x => x.Ders_Id == item.id && x.Durum == true && x.Iptal != true).ToList();
                    if (result.Count() == 0)
                        continue;
                    else
                    {
                        foreach (var a in result)
                        {
                            ogretmen = new GelecekForAll();
                            var ders = _bitirmeContext.tbl_Ders.SingleOrDefault(x => x.id == a.Ders_Id && x.Durum == true);
                            if(ders != null)
                            {
                                ogretmen.DersKodu = ders.Ders_Kodu;
                                ogretmen.DersAdi = ders.Ders_Adi;
                                ogretmen.Sinifi = _bitirmeContext.tbl_Sinif.SingleOrDefault(x => x.id == ders.Sinif_Id).Sinif_Adi;
                                ogretmen.Tarih = a.Tarih;
                                ogretmen.DersSaat_id = a.id;
                            }
                            
                            ListGelecekDers.Add(ogretmen);
                        }
                    }
                }
                return ListGelecekDers;
            }
        }
        public List<DersForOgretmen> GetDers(int id)
        {
            List<DersForOgretmen> dersForOgretmens = new List<DersForOgretmen>();
            DersForOgretmen ogretmen;
            using (var context = new BitirmeContext())
            {
                var dersler = context.tbl_Ders.Where(x => x.Ogretmen_Id == id && x.Durum != false).ToList();
                foreach (var item in dersler)
                {
                    ogretmen = new DersForOgretmen();
                    ogretmen.Ders_Id = item.id;
                    ogretmen.DersAdi = item.Ders_Adi;
                    ogretmen.DersKodu = item.Ders_Kodu;
                    ogretmen.ToplamOgrenci = context.tbl_AlınanDers.Count(x => x.Ders_Id == item.id);
                    ogretmen.DersSinifi = context.tbl_Sinif.SingleOrDefault(x => x.id == item.Sinif_Id).Sinif_Adi;

                    dersForOgretmens.Add(ogretmen);
                }
            }
            return dersForOgretmens;
        }

        public void YoklamaEkleme(int OgrenciId, int Derssaat_id)
        {
            using(BitirmeContext _bitirmeContext = new BitirmeContext())
            {
                Yoklama yoklama = new Yoklama();
                var ders = _bitirmeContext.tbl_Yoklama.SingleOrDefault(x => x.Ogrenci_Id == OgrenciId && x.DersSaat_Id == Derssaat_id);
                if (ders == null)
                {
                    yoklama.Ogrenci_Id = OgrenciId;
                    yoklama.DersSaat_Id = Derssaat_id;
                    yoklama.Durum = true;
                    _bitirmeContext.Add(yoklama);
                }
                else
                {
                    ders.Durum = true;
                }
                _bitirmeContext.SaveChanges();
            }
        }

        public void YoklamaSilme(int YoklamaId, int ogrenciId, int dersSaat_id)
        {
            using(BitirmeContext _bitirmeContext = new BitirmeContext())
            {
                var yoklama = _bitirmeContext.tbl_Yoklama.SingleOrDefault(x => x.id == YoklamaId);
                
                if (yoklama == null)
                    yoklama = _bitirmeContext.tbl_Yoklama.SingleOrDefault(x => x.Ogrenci_Id == ogrenciId && x.DersSaat_Id == dersSaat_id);
               
                if(yoklama == null)
                {
                    yoklama.Ogrenci_Id = ogrenciId;
                    yoklama.DersSaat_Id = dersSaat_id;
                    _bitirmeContext.Add(yoklama);
                }
                yoklama.Durum = false;
               _bitirmeContext.SaveChanges();
                    
                
            }
        }
    }
}
