namespace server.Entities.DTOs
{
    public class AuthDto
    {
        //ogrenci -> 1, ogretmen -> 2, admin -> 3
        public int? Id { get; set; }
        public int? Türü { get; set; }
        public string? KullaniciAdi { get; set; }
        public string? Sifre { get; set; }
    }
}
