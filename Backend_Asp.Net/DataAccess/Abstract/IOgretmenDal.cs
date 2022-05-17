using server.Core.Entities;
using server.Entities.Concrete;
using server.Entities.DTOs;

namespace server.DataAccess.Abstract
{
    public interface IOgretmenDal
    {
        void YoklamaEkleme(int OgrenciId, int Derssaat_id);
        void YoklamaSilme(int YoklamaId, int ogrenciId, int dersSaat_id);
        List<DersForOgretmen> GetDers(int id);
        List<GelecekForAll> GelecekDersGetir(int id);
        List<GelecekForAll> DerseGoreGelecekGetir(int dersId);
        void DersIptal(int DersSaatId);
    }
}
