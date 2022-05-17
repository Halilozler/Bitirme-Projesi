using server.Business.Abstarct;
using server.DataAccess.Abstract;
using server.DataAccess.Concrete;
using server.Entities.DTOs;

namespace server.Business.Concrete
{
    public class AllManager : IAllService
    {
        IAllDal _all;
        public AllManager()
        {
            _all = new EfAllDal();
        }
        public AuthDto login(string username, string password)
        {
            return _all.Giris(username, password);
        }

    }
}
