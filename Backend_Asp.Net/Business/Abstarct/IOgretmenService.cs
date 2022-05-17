using server.Entities.Concrete;
using server.Entities.DTOs;

namespace server.Business.Abstarct
{
    public interface IOgretmenService
    {
        List<DersForOgretmen> GetDers(int OgretmenId);
        List<YoklamaForAll> GetYoklama(int DersId);
        List<GelecekForAll> GetGelecek(int OgretmenId);
        List<BildirimDto> GetBildirims(int OgretmenId);
        DersYoklaması yoklama(int DersSaat_id);
        void yoklamaEkle(int OgrenciId, int Derssaat_id);
        void yoklamaSil(int YoklamaId, int ogrenciId, int dersSaat_id);
        List<GelecekForAll> derseGoreGelecekGetir(int dersId);
        void dersIptal(int DersSaatId);
        List<BildirimDto> getBildirim(int OgretmenId);
    }
}
