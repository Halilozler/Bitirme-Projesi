using server.Entities.Concrete;

namespace server.Entities.DTOs
{
    public class DersYoklaması
    {
        public List<AlınanDers> DersiAlanlar { get; set; }
        public List<YoklamaDto> DerseGelenler { get; set; }
        public List<YoklamaDto> DerseGelmeyenler { get; set; }
    }
}
