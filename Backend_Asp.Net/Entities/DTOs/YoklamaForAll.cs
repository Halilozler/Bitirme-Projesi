using server.Core.Entities;

namespace server.Entities.DTOs
{
    public class YoklamaForAll : IDto
    {
        public bool? OgrenciYoklamaKontrol { get; set; }
        public int DersSaat_Id { get; set; }
        public DateTime YapildigiTarih { get; set; }
        public int KatilanOgrenci { get; set; }
    }
}
