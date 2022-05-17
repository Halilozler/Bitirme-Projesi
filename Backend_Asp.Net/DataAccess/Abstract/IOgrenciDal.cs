using server.Entities.Concrete;
using server.Entities.DTOs;

namespace server.DataAccess.Abstract
{
    public interface IOgrenciDal 
    {
        List<DersForOgrenci> DersGetir(int ogrenciId);
        List<GelecekForAll> GelecekDersGetir(int ogrenciId);
    }
}
