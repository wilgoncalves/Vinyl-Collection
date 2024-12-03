using VinylCollection.Models;

namespace VinylCollection.Data
{
    public class SeedingService
    {
        private VinylCollectionContext _context;

        public SeedingService(VinylCollectionContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Title.Any() || _context.Artist.Any())
            {
                return;
            }

            Artist a1 = new Artist(1, "Planet Hemp");
            Title t1 = new Title(1, "Jardineiros", 2022, a1);

            Artist a2 = new Artist(2, "Elza Soares");
            Title t2 = new Title(2, "No Tempo da Intolerância", 2023, a2);

            Artist a3 = new Artist(3, "Pabllo Vittar");
            Title t3 = new Title(3, "Noitada", 2023, a3);

            Artist a4 = new Artist(4, "Robson Jorge e Lincoln Olivetti");
            Title t4 = new Title(4, "Robson Jorge e Lincoln Olivetti", 1982, a4);

            _context.Artist.AddRange(a1, a2, a3, a4);
            _context.Title.AddRange(t1, t2, t3, t4);

            _context.SaveChanges();
        }
    }
}
