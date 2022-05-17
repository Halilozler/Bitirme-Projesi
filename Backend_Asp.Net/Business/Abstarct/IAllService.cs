using server.Entities.DTOs;

namespace server.Business.Abstarct
{
    public interface IAllService
    {
        AuthDto login(string username, string password);
    }
}
