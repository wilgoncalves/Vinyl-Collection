using Microsoft.AspNetCore.Mvc;
using VinylCollection.Models;

namespace VinylCollection.Controllers
{
    public class TitlesController : Controller
    {
        public IActionResult Index()
        {
            List <Title> list = new List<Title>();
            list.Add(new Title { Id = 1, 
                TitleName = "Letrux como Mulher Girafa", 
                RecordedYear = 2023 });
            list.Add(new Title { Id = 2, 
                TitleName = "Marmota", 
                RecordedYear = 2021 });

            return View(list);
        }
    }
}
