using Microsoft.AspNetCore.Mvc;
using server.Business.Abstarct;
using server.Business.Concrete;

namespace server.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class OgretmenController : ControllerBase
    {

        private readonly IOgretmenService _ogretmenService;
        public OgretmenController()
        {
            _ogretmenService = new OgretmenManager();
        }

        [HttpGet("ders/{Ogretmen_id}")]
        public IActionResult getDers(int Ogretmen_id)
        {
            var result = _ogretmenService.GetDers(Ogretmen_id);
            if(result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("gelecek/{Ogretmen_id}")]
        public IActionResult getGelecek(int Ogretmen_id)
        {
            var result = _ogretmenService.GetGelecek(Ogretmen_id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("derseGetir/{dersId}")]
        public IActionResult getDerseGoreGelecek(int dersId)
        {
            var result = _ogretmenService.derseGoreGelecekGetir(dersId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("gecmisders/{ders_id}")]
        public IActionResult getGecmisDers(int ders_id)
        {
            var result = _ogretmenService.GetYoklama(ders_id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("yoklama/{dersSaat_id}")]
        public IActionResult yoklama(int dersSaat_id)
        {
            var result = _ogretmenService.yoklama(dersSaat_id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpPost("ekle/{OgrenciId}/{Derssaat_id}")]
        public void yoklamaEkle(int OgrenciId, int Derssaat_id)
        {
            _ogretmenService.yoklamaEkle(OgrenciId, Derssaat_id);
        }
        [HttpPost("sil/{YoklamaId}/{OgrenciId}/{DersSaat}")]
        public void yoklamaSil(int YoklamaId, int OgrenciId, int DersSaat)
        {
            if(YoklamaId != 0)
                _ogretmenService.yoklamaSil(YoklamaId,0,0);
            else
            {
                _ogretmenService.yoklamaSil(0,OgrenciId,DersSaat);
            }
        }
        [HttpPost("iptal/{Derssaat_id}")]
        public void DersIptal(int Derssaat_id)
        {
            _ogretmenService.dersIptal(Derssaat_id);
        }
        [HttpGet("bildirim/{OgretmenId}")]
        public IActionResult bildirim(int OgretmenId)
        {
            var result = _ogretmenService.getBildirim(OgretmenId);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
