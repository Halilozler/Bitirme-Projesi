using server.DataAccess;
using server.Entities.Concrete;
using server.Entities.DTOs;

namespace server.Business.Abstarct
{
    public interface IAdminService
    {
        List<Ogrenci> GetAllOgrenci(string? OgrenciAd);
        Ogrenci GetOgrenci(int id);
        List<Ogretmen> GetAllOgretmen(string OgretmenAd);
        List<Ogretmen> BolumeGöreOgretmenGetir(int BolumId);
        List<Admin_DersDto> GetAllDers(string? dersAd);
        List<BildirimDto> GetBildirim();
        List<BolumDto> getBolums();
        List<Ogretim> getOgretim();
        List<Sinif> getSinif();
        Ogretmen GetOgretmen(int id);
        void OgretmenEkle(Ogretmen ogretmen);
        void OgretmenSil(int ogretmenId);
        void OgretmenGüncelle(int id, Ogretmen ogretmen);
        void OgrenciEkle(Ogrenci ogrenci);
        void OgrenciSil(int ogrenciId);
        void OgrenciGüncelle(int id, Ogrenci ogrenci);
        void DersEkle(Ders ders);
        void DersSil(int dersId);
        void DersSaatEkle(DersSaati dersSaati);
        
    }
}
