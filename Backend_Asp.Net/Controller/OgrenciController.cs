using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using server.Business.Abstarct;
using server.Business.Concrete;

namespace server.Controller
{
    //[Authorize] token bilgisi için
    [ApiController]
    [Route("api/[controller]")]
    public class OgrenciController : ControllerBase
    {
        private readonly IOgrenciService _ogrenciService;
        public OgrenciController()
        {
            _ogrenciService = new OgrenciManager();
        }

        [HttpGet("dersgetir/{Ogrenci_id}")]
        public IActionResult DersGetir(int Ogrenci_id)
        {
            return Ok(_ogrenciService.DersleriniGör(Ogrenci_id));
        }

        [HttpGet("gelecek/{Ogrenci_id}")]
        public IActionResult GelecekDersler(int Ogrenci_id)
        {
            return Ok(_ogrenciService.GelecekDersGetir(Ogrenci_id));                                                                                                                                             
        }

        [HttpGet("bildirim/{Ogrenci_id}")]
        public IActionResult BildirimGetir(int Ogrenci_id)
        {
            return Ok(_ogrenciService.GetBildirim(Ogrenci_id));
        }

        [HttpGet("gecmisders/{Ders_id}/{Ogrenci_id}")]
        public IActionResult GecmisDers(int Ders_id,int Ogrenci_id)
        {
            return Ok(_ogrenciService.GetsYoklama(Ders_id, Ogrenci_id));
        }

        [HttpGet("yoklama/{DersSaat_Id}")]
        public IActionResult yoklama(int DersSaat_Id)
        {
            return Ok(_ogrenciService.DersYoklamaGetir(DersSaat_Id));
        }
    }
}
