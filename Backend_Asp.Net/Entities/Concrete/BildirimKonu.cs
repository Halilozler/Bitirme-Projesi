using server.Core.Entities;

namespace server.Entities.Concrete
{
    public class BildirimKonu : IEntity
    {
        public int id { get; set; }
        public string Bildirim_Konu { get; set; }
    }
}
