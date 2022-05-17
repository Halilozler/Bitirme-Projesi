using server.Business.Abstarct;
using server.DataAccess.Abstract;
using server.DataAccess.Concrete;
using server.Entities.Concrete;
using server.Entities.DTOs;

namespace server.Business.Concrete
{
    public class OgretmenManager : IOgretmenService
    {
        EfOgretmenDal _ogretmen;
        public OgretmenManager()
        {
            _ogretmen = new EfOgretmenDal();
        }

        public DersYoklaması yoklama(int DersSaat_id)
        {
            return _ogretmen.DersiAlan(DersSaat_id);
        }

        public List<BildirimDto> GetBildirims(int OgretmenId)
        {
            return _ogretmen.GetsBildirim(OgretmenId, null,false);
        }

        public List<DersForOgretmen> GetDers(int OgretmenId)
        {
            return _ogretmen.GetDers(OgretmenId);
        }

        public List<GelecekForAll> GetGelecek(int OgretmenId)
        {
            return _ogretmen.GelecekDersGetir(OgretmenId);
        }

        public List<YoklamaForAll> GetYoklama(int DersId)
        {
            return _ogretmen.yoklamaForAlls(DersId,null,null);
        }

        public void yoklamaEkle(int OgrenciId, int Derssaat_id)
        {
            _ogretmen.YoklamaEkleme(OgrenciId, Derssaat_id);
        }

        public void yoklamaSil(int YoklamaId, int ogrenciId, int dersSaat_id)
        {
            if(YoklamaId != 0)
                _ogretmen.YoklamaSilme(YoklamaId,0,0);
            else
            {
                _ogretmen.YoklamaSilme(0,ogrenciId,dersSaat_id);
            }
        }

        public List<GelecekForAll> derseGoreGelecekGetir(int dersId)
        {
            return _ogretmen.DerseGoreGelecekGetir(dersId);
        }

        public void dersIptal(int DersSaatId)
        {
            _ogretmen.DersIptal(DersSaatId);
        }

        public List<BildirimDto> getBildirim(int OgretmenId)
        {
            return _ogretmen.GetsBildirim(OgretmenId, null,false);
        }
    }
}
