using server.Core.Entities;

namespace server.Entities.Concrete
{
    public class Sinif : IEntity
    {
        public int id { get; set; }
        public string Sinif_Adi { get; set; }
        public int Aygit_Id { get; set; }

    }
}
