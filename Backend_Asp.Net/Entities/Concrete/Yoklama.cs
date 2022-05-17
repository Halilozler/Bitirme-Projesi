using server.Core.Entities;
using server.DataAccess;

namespace server.Entities.Concrete
{
    public class Yoklama : IEntity
    {
        public int id { get; set; }
        public int Ogrenci_Id { get; set; }
        public int DersSaat_Id { get; set; }
        public bool? Durum { get; set; }

    }
}
