using server.Core.Entities;

namespace server.Entities.Concrete
{
    public class Bolum : IEntity
    {
        public int id { get; set; }
        public int BolumAdi_Id { get; set; }
        public int Fakulte_Id { get; set; }

    }
}
