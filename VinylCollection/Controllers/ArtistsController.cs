using Microsoft.AspNetCore.Mvc;
using VinylCollection.Services;

namespace VinylCollection.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly ArtistService _artistService;

        public ArtistsController(ArtistService artistService)
        {
            _artistService = artistService;
        }

        public IActionResult Index()
        {
            var list = _artistService.FindAll();
            return View(list);
        }
    }
}
