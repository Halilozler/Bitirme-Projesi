using Microsoft.EntityFrameworkCore;
using server.Entities.Concrete;

namespace server.DataAccess
{
    public class BitirmeContext : DbContext
    {
        /*veritabanı bağlama*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=OZLER;Database=bitirme;Trusted_Connection=true");
        }

        //veritabanındaki tablolar ne ile kayıtlı:
        public DbSet<AlınanDers> tbl_AlınanDers { get; set;}
        public DbSet<Ders> tbl_Ders { get; set; }
        public DbSet<DersSaati> tbl_DersSaat{ get; set; }
        public DbSet<Ogrenci> tbl_Ogrenci { get; set; }
        public DbSet<Ogretmen> tbl_Ogretmen { get; set; }
        public DbSet<Yoklama> tbl_Yoklama { get; set; }
        public DbSet<Admin> tbl_Admin { get; set; }
        public DbSet<BolumAdi> tbl_BolumAdi { get; set; }
        public DbSet<Fakulte> tbl_Fakulte { get; set; }
        public DbSet<Bolum> tbl_Bolum { get; set; }
        public DbSet<Aygit> tbl_Aygit { get; set; }
        public DbSet<Sinif> tbl_Sinif { get; set; }
        public DbSet<Ogretim> tbl_Ogretim { get; set; }
        public DbSet<BildirimKonu> tbl_BildirimKonu { get; set; }
        public DbSet<Bildirim> tbl_Bildirim { get; set; }
    }
}
