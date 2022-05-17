using server.Core.Entities;

namespace server.Entities.Concrete
{
    public class DersSaati : IEntity
    {
        public int id { get; set; }
        public int Ders_Id { get; set; }
        public DateTime Tarih { get; set; }
        public bool? Durum { get; set; }
        public bool? Iptal { get; set; }

    }
}
