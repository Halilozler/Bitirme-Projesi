using server.Core.Entities;
using server.Entities.Concrete;
using server.Entities.DTOs;
using System.Linq.Expressions;

namespace server.DataAccess.Abstract
{
    public interface IAdminDal:IAllDal
    {
        void Add<T>(T entity) where T : class, IEntity;
        void Update<T>(T entity) where T : class, IEntity; 
        void Delete<T>(T entity) where T : class, IEntity;
        T Get<T>(Expression<Func<T, bool>> filter) where T : class, IEntity;
        List<T> GetAll<T>(Expression<Func<T, bool>> filter = null) where T : class, IEntity;

        List<Admin_DersDto> getDersler(string? DersAd);
        List<BolumDto> getBolum();
    }
}
