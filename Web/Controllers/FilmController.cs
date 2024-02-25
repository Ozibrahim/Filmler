using Entity.Entity;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;

namespace Web.Controllers
{
    public class FilmController : Controller
    {

        private readonly ILogger<FilmController> _logger;

        private readonly IGenericService<Film_Tbl> _filmService;
        private readonly IGenericService<Kategori_Tbl> _kategoriService;
        private readonly IGenericService<Yonetmen_Tbl> _yonetmenService;
        private readonly IUnitOfWork _unitOfWork;


        public FilmController(ILogger<FilmController> logger, IGenericService<Film_Tbl> filmService, IGenericService<Kategori_Tbl> kategoriService, IGenericService<Yonetmen_Tbl> yonetmenService, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _filmService = filmService;
            _kategoriService = kategoriService;
            _yonetmenService = yonetmenService;
            _unitOfWork = unitOfWork;
        }

        public IActionResult FilmIndex()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FilmListele()
        {
            string[] includes = { "Kategori", "Yonetmen" };
            var filmler = _filmService.GetList(x => x.Silindi == false, includes).ToList(); 

            return View(filmler);
        }

        [HttpGet]
        public IActionResult FilmEkle()
        {
            var kategoriler = _kategoriService.GetList(x => true).ToList();
            ViewBag.Kategoriler = kategoriler;

            var yonetmenler = _yonetmenService.GetList(x => true).ToList();
            ViewBag.Yonetmenler = yonetmenler;
            return View();
        }

        [HttpPost]
        public IActionResult FilmEkle(Film_Tbl film_Tbl)
        {
            if (film_Tbl == null)
            {
                return BadRequest("Eklenecek Film Bulunamadı.");
            }

            _filmService.AddAsync(film_Tbl);
            _unitOfWork.Commit();
            return Ok("Film Kaydedildi.");
        }

        [HttpGet]
        public async Task <IActionResult> FilmGuncelle(int filmId) 
        {
            var film =await _filmService.FirstOrDefault(x => x.FilmId == filmId && x.Silindi == false);

            var kategoriler = _kategoriService.GetList(x => true).ToList();
            ViewBag.Kategoriler = kategoriler;

            var yonetmenler = _yonetmenService.GetList(x => true).ToList();
            ViewBag.Yonetmenler = yonetmenler;

            return View(film);
        }
        [HttpPost]
        public IActionResult FilmGuncelle(Film_Tbl film_Tbl)
        {
            if (film_Tbl == null)
            {
                return BadRequest("Film Guncellenmedi.");
            }
            _filmService.UpdateAsync(film_Tbl);
            _unitOfWork.Commit();
            return Ok("Film Guncellendi.");
        }
        [HttpGet]
        public async Task<IActionResult> FilmSil(int filmId)
        {
            var film = await _filmService.FirstOrDefault(x => x.FilmId == filmId && x.Silindi == false);

            film.Silindi = true;

            _filmService.UpdateAsync(film);
            _unitOfWork.Commit();
            return Ok("Film silindi.");
        }
        


    }
}
