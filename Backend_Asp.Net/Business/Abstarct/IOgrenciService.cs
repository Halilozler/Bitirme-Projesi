using server.Entities.Concrete;
using server.Entities.DTOs;

namespace server.Business.Abstarct
{
    public interface IOgrenciService
    {
        List<DersForOgrenci> DersleriniGör(int öğrenciId);
        List<BildirimDto> GetBildirim(int ogrenciId);
        List<GelecekForAll> GelecekDersGetir(int ogrenciId);
        List<YoklamaForAll> GetsYoklama(int ders_Id, int ogrenci_Id);
        List<YoklamaDto> DersYoklamaGetir(int dersSaat_Id); 
    }
}
