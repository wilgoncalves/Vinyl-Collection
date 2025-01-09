using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VinylCollection.Data;
using VinylCollection.Models;
using VinylCollection.Models.ViewModels;
using VinylCollection.Services;

namespace VinylCollection.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly VinylCollectionContext _context;
        private readonly ArtistService _artistService;

        public ArtistsController(VinylCollectionContext context, ArtistService artistService)
        {
            _context = context;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtistName")] Artist artist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(artist);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(artist);
        }
    }
}