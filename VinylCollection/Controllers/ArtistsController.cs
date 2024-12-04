using Microsoft.AspNetCore.Mvc;

namespace VinylCollection.Controllers
{
    public class ArtistsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
