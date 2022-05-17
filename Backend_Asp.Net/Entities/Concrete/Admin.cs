using server.Core.Entities;

namespace server.Entities.Concrete
{
    public class Admin : IEntity
    {
        public int id { get; set; }
        public string Admin_KullanıcıAdi { get; set; }
        public string Admin_Sifre { get; set; }
    }
}
