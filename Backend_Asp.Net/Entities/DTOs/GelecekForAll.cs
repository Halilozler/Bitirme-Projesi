using server.Core.Entities;

namespace server.Entities.DTOs
{
    public class GelecekForAll : IDto
    {
        public int? DersSaat_id { get; set; }
        public string? DersKodu { get; set; }
        public string? DersAdi { get; set; }
        public string? Sinifi { get; set; }
        public DateTime Tarih { get; set; }
    }
}
