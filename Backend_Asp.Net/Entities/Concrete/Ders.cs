using server.Core.Entities;

namespace server.Entities.Concrete
{
    public class Ders : IEntity
    {
        public int id { get; set; }
        public string Ders_Kodu { get; set; }
        public string Ders_Adi { get; set; }
        public bool Durum { get; set; }
        public int Ogretmen_Id { get; set; }
        public int Bolum_Id { get; set; }
        public int Ogretim_Id { get; set; }
        public int Sinif_Id { get; set; }
    }
}
