using server.Core.Entities;

namespace server.Entities.DTOs
{
    public class BildirimDto : IDto
    {
        public string Baslik { get; set; }
        public string Ders_Kodu { get; set; }
        public string Ders_Adi { get; set; }
        public DateTime OlusturulduguTarih { get; set; }
        public DateTime dersSaati { get; set; }
        public DateTime? YeniSaati { get; set; }
        public string? YeniSinifi { get; set; }
    }
}
