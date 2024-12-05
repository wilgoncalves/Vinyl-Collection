using VinylCollection.Data;
using VinylCollection.Models;

namespace VinylCollection.Services
{
    public class ArtistService
    {
        private readonly VinylCollectionContext _context;

        public ArtistService(VinylCollectionContext context)
        {
            _context = context;
        }

        public List<Artist> FindAll()
        {
            return _context.Artist.ToList();
        }
    }
}
