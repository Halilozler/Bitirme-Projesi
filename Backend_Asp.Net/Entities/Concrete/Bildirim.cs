using server.Core.Entities;

namespace server.Entities.Concrete
{
    public class Bildirim : IEntity
    {
        public int id { get; set; }
        public int BildirimKonu_Id { get; set; }
        public int DersSaat_Id { get; set; }
        public DateTime? EskiSaat { get; set; }
        public DateTime? YeniSaat { get; set; }
        public int? YeniSinif_Id { get; set; }
        public bool? Durum { get; set; }
        public DateTime Olusturuldugu_Tarih { get; set; }
    }
}
