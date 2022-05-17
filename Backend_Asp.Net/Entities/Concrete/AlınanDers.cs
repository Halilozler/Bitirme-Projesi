using server.Core.Entities;
using server.DataAccess;

namespace server.Entities.Concrete
{
    public class AlınanDers : IEntity
    {
        public int id { get; set; }
        public int Ogrenci_Id { get; set; }
        public int Ders_Id { get; set; }

    }
}
