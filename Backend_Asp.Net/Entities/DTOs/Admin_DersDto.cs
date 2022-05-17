namespace server.Entities.DTOs
{
    public class Admin_DersDto
    {
        public int DersId { get; set; }
        public string DersAdi { get; set; }
        public string DersKodu { get; set; }
        public bool Durum { get; set; }
        public int Ogretmen_Id { get; set; }
        public int Bolum_Id { get; set; }
        public int Ogretim_Id { get; set; }
        public int Sinif_Id { get; set; }
        public string OgretmenAd { get; set; }
        public string OgretmenSoyad { get; set; }
        public string BolumAd { get; set; }
        public string OgretimAd { get; set; }
        public string SinifAd { get; set; }

        public Admin_DersDto(int dersId, string dersAdi, string dersKodu, bool durum, int ogretmen_Id, int bolum_Id, int ogretim_Id, int sinif_Id)
        {
            DersId = dersId;
            DersAdi = dersAdi;
            DersKodu = dersKodu;
            Durum = durum;
            Ogretmen_Id = ogretmen_Id;
            Bolum_Id = bolum_Id;
            Ogretim_Id = ogretim_Id;
            Sinif_Id = sinif_Id;
        }
    }
}
