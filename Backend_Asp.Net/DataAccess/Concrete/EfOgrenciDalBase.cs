using server.Entities.DTOs;

namespace server.DataAccess.Concrete
{
    public class EfOgrenciDalBase
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
    }
}