using server.Core.Entities;

namespace server.Entities.DTOs
{
    public class DersForOgretmen : IDto
    {
        public int Ders_Id { get; set; }
        public string DersAdi { get; set; }
        public string DersKodu { get; set; }
        public string DersSinifi { get; set; }
        public int ToplamOgrenci { get; set; }
    }
}
