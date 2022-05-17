using server.Core.Entities;
using server.Entities.Concrete;

namespace server.Entities.DTOs
{
    public class DersForOgrenci : IDto
    {
        public int Ders_Id { get; set; }
        public string DersAdi { get; set; }
        public string DersKodu { get; set; }
        public string OgretmenAdi { get; set; }
        public int ToplamDers { get; set; }
        public int KatildigiDers { get; set; }
    }
}
