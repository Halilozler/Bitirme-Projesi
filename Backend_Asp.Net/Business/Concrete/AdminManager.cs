using server.Business.Abstarct;
using server.DataAccess;
using server.DataAccess.Abstract;
using server.DataAccess.Concrete;
using server.Entities.Concrete;
using server.Entities.DTOs;

namespace server.Business.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _admin;
        public AdminManager()
        {
            _admin = new EfAdminDal();
        }

        public List<Admin_DersDto> GetAllDers(string? dersAd)
        {
            return _admin.getDersler(dersAd);
        }

        public List<Ogrenci> GetAllOgrenci(string? OgrenciAd)
        {
            if(OgrenciAd == null)
                return _admin.GetAll<Ogrenci>();

            return _admin.GetAll<Ogrenci>(x => x.Ogrenci_Adi.Contains(OgrenciAd));
        }

        public List<Ogretmen> GetAllOgretmen(string? OgretmenAd)
        {
            if(OgretmenAd == null)
                return _admin.GetAll<Ogretmen>();

            return _admin.GetAll<Ogretmen>(x => x.Ogretmen_Adi.Contains(OgretmenAd));
        }

        public List<BildirimDto> GetBildirim()
        {
            return _admin.GetsBildirim(0, false, true);
        }

        public Ogrenci GetOgrenci(int id)
        {
            return _admin.Get<Ogrenci>(x => x.id == id);
        }

        public Ogretmen GetOgretmen(int id)
        {
            return _admin.Get<Ogretmen>(x => x.id == id);
        }

        public void OgrenciEkle(Ogrenci ogrenci)
        {
            var ogrenciVarmı = _admin.Get<Ogrenci>(x => x.Ogrenci_No == ogrenci.Ogrenci_No);
            var ogrenciVarmı_2 = _admin.Get<Ogrenci>(x => x.Ogrenci_Tc == ogrenci.Ogrenci_Tc);
            if(ogrenciVarmı == null && ogrenciVarmı_2 == null)
            {
                _admin.Add<Ogrenci>(ogrenci);
            }
        }

        public void OgrenciGüncelle(int id, Ogrenci ogrenci)
        {
            if(ogrenci != null)
            {
                if (_admin.GetAll<Ogrenci>(x => x.Ogrenci_No == ogrenci.Ogrenci_No && x.id != id).Count() == 0)
                {
                    if (_admin.GetAll<Ogrenci>(x => x.Ogrenci_Tc == ogrenci.Ogrenci_Tc && x.id != id).Count() == 0)
                    {
                        ogrenci.id = id;
                        //AsılOgrenci = ogrenci;
                        _admin.Update<Ogrenci>(ogrenci);
                    }
                    else
                    {
                        Console.WriteLine("Başka biri ile Tc Numarası aynı olamaz");
                    }
                }
                else
                {
                    //burada başka bir tc li vatandaş ile aynı mesajı gönder
                    Console.WriteLine("Başka biri ile Okul Numarası aynı olamaz");
                }
            }    
        }

        public void OgrenciSil(int ogrenciId)
        {
            Ogrenci ogrenci = _admin.Get<Ogrenci>(x => x.id == ogrenciId);
            if(ogrenci != null)
            {
                ogrenci.Durum = false;
                _admin.Delete<Ogrenci>(ogrenci);
            }
        }

        public void OgretmenEkle(Ogretmen ogretmen)
        {
            var ogretmenVarmı = _admin.Get<Ogretmen>(x => x.Ogretmen_Tc == ogretmen.Ogretmen_Tc);
            if (ogretmenVarmı == null)
            {
                ogretmen.Durum = true;
                _admin.Add<Ogretmen>(ogretmen);
            }
        }

        public void OgretmenGüncelle(int id, Ogretmen ogretmen)
        {
            if (ogretmen != null)
            {
                if (_admin.GetAll<Ogretmen>(x => x.Ogretmen_Tc == ogretmen.Ogretmen_Tc && x.id != id).Count() == 0)
                {
                    ogretmen.id = id;
                    _admin.Update<Ogretmen>(ogretmen);
                }
                else
                {
                    //burada başka bir tc li vatandaş ile aynı mesajı gönder
                    Console.WriteLine("Başka biri ile Tc Numarası aynı olamaz");
                }
            }
        }

        public void OgretmenSil(int ogretmenId)
        {
            Ogretmen ogretmen = _admin.Get<Ogretmen>(x => x.id == ogretmenId);
            if (ogretmen != null)
            {
                ogretmen.Durum = false;
                _admin.Delete<Ogretmen>(ogretmen);
            }
        }


        public void DersEkle(Ders ders)
        {
            _admin.Add<Ders>(ders);
        }

        public void DersSil(int dersId)
        {
            Ders ders = _admin.Get<Ders>(x => x.id == dersId);
            if(ders != null)
            {
                ders.Durum = false;
                _admin.Delete<Ders>(ders);
            }
        }

        public List<BolumDto> getBolums()
        {
            return _admin.getBolum();
        }

        public List<Ogretmen> BolumeGöreOgretmenGetir(int BolumId)
        {
            return _admin.GetAll<Ogretmen>(x => x.Bolum_Id == BolumId);
        }

        public List<Ogretim> getOgretim()
        {
            return _admin.GetAll<Ogretim>();
        }

        public List<Sinif> getSinif()
        {
            return _admin.GetAll<Sinif>();
        }

        public void DersSaatEkle(DersSaati dersSaati)
        {
            _admin.Add<DersSaati>(dersSaati);
        }
    }
}
