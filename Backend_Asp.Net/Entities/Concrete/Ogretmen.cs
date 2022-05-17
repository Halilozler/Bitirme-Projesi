using server.Core.Entities;

namespace server.Entities.Concrete
{
    public class Ogretmen : IEntity
    {
        public int id { get; set; }
        public string Ogretmen_Adi { get; set; }
        public string Ogretmen_Soyadi { get; set; }
        public string Ogretmen_Tc { get; set; }
        public string Ogretmen_Sifre { get; set; }
        public int Bolum_Id { get; set; }
        public bool Durum { get; set; }

    }
}
