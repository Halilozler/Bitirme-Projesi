using server.Entities.Concrete;
using server.Entities.DTOs;

namespace server.DataAccess.Abstract
{
    public interface IAllDal
    {
        List<YoklamaForAll> yoklamaForAlls(int ders_Id, bool? Ogrenci, int? ogrenci_Id);
        List<BildirimDto> GetsBildirim(int id, bool? ogrenci, bool admin);
        List<YoklamaDto> GetsYoklama(int Ders_saatId);
        AuthDto Giris(string KullaniciAdi, string Sifre);
        DersYoklaması DersiAlan(int DersSaat_id);
    }
}
