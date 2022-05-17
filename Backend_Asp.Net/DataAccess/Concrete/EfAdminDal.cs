using server.Entities.Concrete;
using server.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using server.Core.Entities;
using System.Linq.Expressions;
using server.Entities.DTOs;

namespace server.DataAccess.Concrete
{
    public class EfAdminDal :EfAllDal, IAdminDal
    {


        public List<Admin_DersDto> getDersler(string? DersAd)
        {
            using(BitirmeContext _context = new BitirmeContext())
            {
                List<Admin_DersDto> admin_DersDtos = new List<Admin_DersDto>(); 
                var dersler = _context.tbl_Ders.OrderBy(x => x.Ogretim_Id).ToList();
                    
                if(DersAd != null)
                {
                    foreach (var item in dersler)
                    {
                        item.Ders_Adi = item.Ders_Adi.ToLower();
                    }
                    DersAd = DersAd.ToLower();
                    dersler = dersler.Where(x => x.Ders_Adi.Contains(DersAd)).ToList();
                }
                    

                Admin_DersDto ders;
                foreach (var item in dersler)
                {
                    ders = new Admin_DersDto(item.id,item.Ders_Adi,item.Ders_Kodu,item.Durum,item.Ogretmen_Id,item.Bolum_Id,item.Ogretim_Id,item.Sinif_Id);

                    var ogretmen = _context.tbl_Ogretmen.SingleOrDefault(x => x.id == item.Ogretmen_Id);
                    ders.OgretmenAd = ogretmen.Ogretmen_Adi;
                    ders.OgretmenSoyad = ogretmen.Ogretmen_Soyadi;

                    var bolumAdi = _context.tbl_BolumAdi.SingleOrDefault(x => x.id == _context.tbl_Bolum.SingleOrDefault(x => x.id == item.Bolum_Id).BolumAdi_Id);
                    ders.BolumAd = bolumAdi.Bolum_Adi;

                    var ogretimAd = _context.tbl_Ogretim.SingleOrDefault(x => x.id==item.Ogretim_Id);
                    ders.OgretimAd = ogretimAd.Ogretim_Adi;

                    var sinif = _context.tbl_Sinif.SingleOrDefault(x => x.id == item.Sinif_Id);
                    ders.SinifAd = sinif.Sinif_Adi;

                    admin_DersDtos.Add(ders);
                }
                return admin_DersDtos;
            }
        }

        T IAdminDal.Get<T>(Expression<Func<T, bool>> filter)
        {
            using (BitirmeContext _context = new BitirmeContext())
            {
                return _context.Set<T>().SingleOrDefault(filter);
            }
        }

        List<T> IAdminDal.GetAll<T>(Expression<Func<T, bool>> filter)
        {
            using (BitirmeContext _context = new BitirmeContext())
            {
                try
                {
                    return filter == null ? _context.Set<T>().ToList() : _context.Set<T>().Where(filter).ToList();
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        void IAdminDal.Add<T>(T entity)
        {
            using (BitirmeContext _context = new BitirmeContext())
            {
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        void IAdminDal.Update<T>(T entity)
        {
            using (BitirmeContext _context = new BitirmeContext())
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        void IAdminDal.Delete<T>(T entity)
        {
            //burada yine update gibi işlicek ama businnes katmanından sadece Durum=false gönderilebilir.
            using (BitirmeContext _context = new BitirmeContext())
            {
                var removeEntity = _context.Entry(entity);
                removeEntity.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public List<BolumDto> getBolum()
        {
            using(BitirmeContext _context = new BitirmeContext())
            {
                List<BolumDto> dtos = new List<BolumDto>();
                var bolum = _context.tbl_Bolum.ToList();
                BolumDto bolumDto;
                foreach (var item in bolum)
                {
                    bolumDto = new BolumDto();
                    bolumDto.BolumAd = _context.tbl_BolumAdi.SingleOrDefault(x => x.id == item.BolumAdi_Id).Bolum_Adi;
                    bolumDto.BolumId = item.id;

                    dtos.Add(bolumDto);
                }
                return dtos;
            }
        }
    }
}
