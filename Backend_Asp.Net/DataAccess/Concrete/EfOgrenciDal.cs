using server.Entities.Concrete;
using server.DataAccess.Abstract;
using server.Entities.DTOs;
using Microsoft.Data.SqlClient;

namespace server.DataAccess.Concrete
{
    public class EfOgrenciDal :EfAllDal, IOgrenciDal
    {
        //ana sayfada her bir aldığı ders için yoklamasını ve toplam kaç derse girdiğini görücek
        public List<DersForOgrenci> DersGetir(int ogrenciId)
        {
            List<DersForOgrenci> dersForOgrencis = new List<DersForOgrenci>();
            using (BitirmeContext _bitirmeContext = new BitirmeContext())
            {
                //öğrencinin alınan derslerden ders_ıd ve Ogrenci_ıd geliyor
                var Aldığıders = _bitirmeContext.tbl_AlınanDers.Where(x => x.Ogrenci_Id == ogrenciId).ToList();

                DersForOgrenci dersForOgrenci;
                foreach (var item in Aldığıders)
                {
                    dersForOgrenci = new DersForOgrenci();
                    var ders = _bitirmeContext.tbl_Ders.SingleOrDefault(x => x.id == item.Ders_Id);
                    var ogretmen = _bitirmeContext.tbl_Ogretmen.SingleOrDefault(x => x.id == 1 && x.Durum == true);
                    dersForOgrenci.Ders_Id = ders.id;
                    dersForOgrenci.DersKodu = ders.Ders_Kodu;
                    dersForOgrenci.DersAdi = ders.Ders_Adi;
                    dersForOgrenci.OgretmenAdi = ogretmen.Ogretmen_Adi + " " + ogretmen.Ogretmen_Soyadi;

                    var dersSaat = _bitirmeContext.tbl_DersSaat.Where(x => x.Ders_Id == ders.id && x.Durum == false && x.Iptal != true).ToList();
                    int count = 0;
                    if (dersSaat.Count != 0)
                    {
                        dersForOgrenci.ToplamDers = dersSaat.Count; ;
                        foreach (var yapılanDers in dersSaat)
                        {
                            var yoklama = _bitirmeContext.tbl_Yoklama.Count(x => x.Ogrenci_Id == ogrenciId && x.DersSaat_Id == yapılanDers.id);
                            if (yoklama != 0)
                                count++;
                        }
                    }
                    else
                    {
                        dersForOgrenci.ToplamDers = 0;
                    }
                    dersForOgrenci.KatildigiDers = count;
                    dersForOgrencis.Add(dersForOgrenci);
                }
                return dersForOgrencis;
            }
            
        }
        //geleceke dersleri görmesi için:
        public List<GelecekForAll> GelecekDersGetir(int ogrenciId)
        {
            List<GelecekForAll> gelecekForOgrencis = new List<GelecekForAll>();
            using (BitirmeContext _bitirmeContext = new BitirmeContext())
            {
                GelecekForAll gelecekForOgrenci;
                var dersler = _bitirmeContext.tbl_AlınanDers.Where(x => x.Ogrenci_Id == ogrenciId).ToList();
                foreach (var item in dersler)
                {
                    var result = _bitirmeContext.tbl_DersSaat.Where(x => x.Ders_Id == item.Ders_Id && x.Durum == true).ToList();
                    if(result.Count() == 0)
                        continue;
                    else
                    {
                        foreach (var a in result)
                        {
                            gelecekForOgrenci = new GelecekForAll();
                            var ders = _bitirmeContext.tbl_Ders.SingleOrDefault(x => x.id == a.Ders_Id);
                            gelecekForOgrenci.DersKodu = ders.Ders_Kodu;
                            gelecekForOgrenci.DersAdi = ders.Ders_Adi;
                            gelecekForOgrenci.Sinifi = _bitirmeContext.tbl_Sinif.SingleOrDefault(x => x.id == ders.Sinif_Id).Sinif_Adi;
                            gelecekForOgrenci.Tarih = a.Tarih;

                            gelecekForOgrencis.Add(gelecekForOgrenci);
                        }
                    }
                }
                return gelecekForOgrencis;
            }
        }
    }
}
