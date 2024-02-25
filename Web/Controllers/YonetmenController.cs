using Entity.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

namespace Web.Controllers
{
    public class YonetmenController : Controller

    {
        private readonly ILogger<YonetmenController> _logger;
        private readonly IGenericService<Yonetmen_Tbl> _yonetmenService;
        private readonly IUnitOfWork _unitOfWork;

        public YonetmenController(ILogger<YonetmenController> logger, IGenericService<Yonetmen_Tbl> yonetmenService, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _yonetmenService = yonetmenService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult YonetmenListele()
        {
            var yonetmenler = _yonetmenService.GetList(x => x.Silindi == false).ToList();

            return View(yonetmenler);
        }
        [HttpGet]
        public IActionResult YonetmenEkle()
        {
            return View();
        }


        [HttpPost]
        public IActionResult YonetmenEkle(Yonetmen_Tbl yonetmen_Tbl)
        {
            if (yonetmen_Tbl == null)
            {
                return BadRequest("Eklenecek Yönetmen Bulunamadı.");
            }

            _yonetmenService.AddAsync(yonetmen_Tbl);
            _unitOfWork.Commit();
            return Ok("Yönetmen Kaydedildi.");

        }

        [HttpGet]
        public async Task<IActionResult> YonetmenGuncelle(int yonetmenId)
        {
            var yonetmen = await _yonetmenService.FirstOrDefault(x => x.YonetmenId == yonetmenId && x.Silindi == false);

            return View(yonetmen);
        }

        [HttpPost]
        public IActionResult YonetmenGuncelle(Yonetmen_Tbl yonetmen_Tbl)
        {
            if (yonetmen_Tbl == null)
            {
                return BadRequest("Yönetmen Güncellenmedi.");
            }
            _yonetmenService.UpdateAsync(yonetmen_Tbl);
            _unitOfWork.Commit();
            return Ok("Yönetmen Guncellendi.");
        }
        [HttpGet]
        public async Task<IActionResult> YonetmenSil(int yonetmenId)
        {
            var yonetmen = await _yonetmenService.FirstOrDefault(x => x.YonetmenId == yonetmenId && x.Silindi == false);

            yonetmen.Silindi = true;

            _yonetmenService.UpdateAsync(yonetmen);
            _unitOfWork.Commit();
            return Ok("Yönetmen silindi.");
        }
    }
}
