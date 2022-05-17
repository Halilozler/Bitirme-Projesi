using server.Core.Entities;
using server.Entities.Concrete;

namespace server.DataAccess
{
    public class Ogrenci : IEntity
    {
        public int id { get; set; }
        public string Ogrenci_Adi { get; set; }
        public string Ogrenci_Soyadi { get; set; }
        public string Ogrenci_No { get; set; }
        public string Ogrenci_Tc { get; set; }
        public string Ogrenci_Sifre { get; set; }
        public int Bolum_Id { get; set; }
        public bool? Durum { get; set; }

    }
}
