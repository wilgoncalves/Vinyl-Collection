using Microsoft.AspNetCore.Mvc;
using VinylCollection.Models;
using VinylCollection.Models.ViewModels;
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
            List<Models.Artist> artists = _artistService.FindAll() ?? new List<Artist>();

            var viewModel = artists.Select(artist => new ArtistViewModel
            {
                ArtistName = artist.ArtistName,
                Titles = artist.Titles!.Select(title => title.TitleName).ToList() ?? new List<string>()
            }).ToList();

            return View(viewModel); 
        }
    }
}