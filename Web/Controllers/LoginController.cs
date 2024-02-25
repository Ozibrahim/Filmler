using Entity.Entity;
using Microsoft.AspNetCore.Mvc;
using Service;
using System.Diagnostics;
using Web.Models;


namespace Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IGenericService<Kullanici_Tbl> _kullaniciService;

        public LoginController(ILogger<LoginController> logger, IGenericService<Kullanici_Tbl> kullaniciService)
        {
            _logger = logger;
            _kullaniciService = kullaniciService;
        }
        [HttpGet]
        public IActionResult KullaniciGiris()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KullaniciGiris(string kullaniciAdi,string sifre)
        {
            var kullanici = _kullaniciService.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == sifre).Result;
            if (kullanici == null)
            {
                return NotFound("Kullanici Bulunamadi.");
            }

            return RedirectToAction("FilmListele","Film");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}