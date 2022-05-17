using Microsoft.AspNetCore.Mvc;
using server.Business.Abstarct;
using server.Business.Concrete;
using server.DataAccess.Abstract;
using server.DataAccess.Concrete;
using server.Entities.Concrete;

namespace server.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IAdminDal _admin;
        public AdminController()
        {
            _adminService = new AdminManager();
            _admin = new EfAdminDal();
        }

        [HttpGet("bolum")]
        public IActionResult GetBolum()
        {
            var result = _adminService.getBolums();
            return Ok(result);
        }

        [HttpGet("ogretim")]
        public IActionResult GetOgretim()
        {
            var result = _adminService.getOgretim();
            return Ok(result);
        }

        [HttpGet("sinif")]
        public IActionResult GetSinif()
        {
            var result = _adminService.getSinif();
            return Ok(result);
        }

        [HttpGet("bolumOgretmen/{BolumId}")]
        public IActionResult GetBolumeOgretmen(int BolumId)
        {
            var result = _adminService.BolumeGöreOgretmenGetir(BolumId);
            return Ok(result);
        }

        [HttpGet("bildirim")]
        public IActionResult GetBildirim()
        {
            var result = _adminService.GetBildirim();
            return Ok(result);
        }
        [HttpGet("ogretmenler/{OgretmenAd}")]
        public IActionResult GetOgretmens(string OgretmenAd)
        {
            if (OgretmenAd == "987")
                OgretmenAd = null;
            var result = _adminService.GetAllOgretmen(OgretmenAd);
            return Ok(result);
        }
        [HttpGet("ogrenciler/{OgrenciAd}")]
        public IActionResult GetOgrenci(string OgrenciAd)
        {
            if (OgrenciAd == "987")
                OgrenciAd = null;
            var result = _adminService.GetAllOgrenci(OgrenciAd);
            return Ok(result);
        }
        [HttpGet("dersler/{DersAd}")]
        public IActionResult GetDersler(string DersAd)
        {
            if (DersAd == "987")
                DersAd = null;
            var result = _adminService.GetAllDers(DersAd);
            return Ok(result);
        }

        [HttpPost("dersSil/{DersId}/{adminId}/{sifre}")]
        public IActionResult DersSil(int DersId, int adminId, string sifre)
        {
            Boolean dogru = AdminCheck(adminId, sifre);
            if(!dogru)
                return Unauthorized();

            _adminService.DersSil(DersId);
            return Ok();
        }

        [HttpPost("dersEkle/{adminId}/{sifre}")]
        public IActionResult DersEkle(Ders ders, int adminId, string sifre)
        {
            Boolean dogru = AdminCheck(adminId, sifre);
            if (!dogru)
                return Unauthorized();
            _adminService.DersEkle(ders);
            return Ok();
        }

        [HttpPost("dersSaatEkle")]
        public IActionResult DersSaatEkle(DersSaati ders)
        {
            ders.Durum = true;
            _adminService.DersSaatEkle(ders);
            return Ok();
        }

        private Boolean AdminCheck(int AdminId, string sifre)
        {
            var admin = _admin.Get<Admin>(x => x.id == AdminId);
            if(admin == null)
                return false;

            if(admin.Admin_Sifre == sifre)
                return true;

            return false;
        }

    }
}
