using Microsoft.EntityFrameworkCore;
using server.Business.Abstarct;
using server.DataAccess.Abstract;
using server.DataAccess.Concrete;
using server.Entities.DTOs;

namespace server.Business.Concrete
{
    public class OgrenciManager : IOgrenciService
    {
        EfOgrenciDal _ogrenci;
        public OgrenciManager()
        {
            _ogrenci = new EfOgrenciDal();
        }
        public List<DersForOgrenci> DersleriniGör(int öğrenciId)
        {
            return _ogrenci.DersGetir(öğrenciId);
        }

        public List<GelecekForAll> GelecekDersGetir(int ogrenciId)
        {
            return _ogrenci.GelecekDersGetir(ogrenciId);
        }

        public List<BildirimDto> GetBildirim(int ogrenciId)
        {
            return _ogrenci.GetsBildirim(ogrenciId, true, false);
        }

        public List<YoklamaForAll> GetsYoklama(int ders_Id, int ogrenci_Id)
        {
            return _ogrenci.yoklamaForAlls(ders_Id, true, ogrenci_Id);
        }

        public List<YoklamaDto> DersYoklamaGetir(int dersSaat_Id)
        {
            return _ogrenci.GetsYoklama(dersSaat_Id);
        }
    }
}
