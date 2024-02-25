using Entity.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

namespace Web.Controllers
{
    public class KategoriController : Controller
    {
        private readonly ILogger<KategoriController> _logger;
        private readonly IGenericService<Kategori_Tbl> _kategoriService;
        private readonly IUnitOfWork _unitOfWork;

        public KategoriController(ILogger<KategoriController> logger, IGenericService<Kategori_Tbl> kategoriService, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _kategoriService = kategoriService;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult KategoriListele()
        {
            var kategoriler = _kategoriService.GetList(x =>x.Silindi == false).ToList();
            
            return View(kategoriler);
        }
        [HttpGet]
        public IActionResult KategoriEkle()
        {
            return View();
        }
       
        
        [HttpPost]
        public IActionResult KategoriEkle(Kategori_Tbl kategori_Tbl)
        {
            if (kategori_Tbl == null)
            {
                return BadRequest("Eklenecek Kategori Bulunamadı.");
            }

            _kategoriService.AddAsync(kategori_Tbl);
            _unitOfWork.Commit();
            return Ok("Film Kaydedildi.");

        }

        [HttpGet]
        public async Task<IActionResult> KategoriGuncelle(int kategoriId)
        {
            var kategori = await _kategoriService.FirstOrDefault(x => x.KategoriId == kategoriId && x.Silindi == false);
                        
            return View(kategori);
        }

        [HttpPost]
        public IActionResult KategoriGuncelle(Kategori_Tbl kategori_Tbl)
        {
            if (kategori_Tbl == null)
            {
                return BadRequest("Kategori Güncellenmedi.");
            }
            _kategoriService.UpdateAsync(kategori_Tbl);
            _unitOfWork.Commit();
            return Ok("Kategori Guncellendi.");
        }
        [HttpGet]
        public async Task<IActionResult> KategoriSil(int kategoriId)
        {
            var kategori = await _kategoriService.FirstOrDefault(x => x.KategoriId == kategoriId && x.Silindi == false);

            kategori.Silindi = true;

            _kategoriService.UpdateAsync(kategori);
            _unitOfWork.Commit();
            return Ok("Film silindi.");
        }
    }
}
