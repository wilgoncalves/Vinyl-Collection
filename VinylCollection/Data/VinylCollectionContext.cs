using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VinylCollection.Models;

namespace VinylCollection.Data
{
    public class VinylCollectionContext : DbContext
    {
        public VinylCollectionContext (DbContextOptions<VinylCollectionContext> options)
            : base(options)
        {
        }

        public DbSet<VinylCollection.Models.Title> Title { get; set; } = default!;
    }
}
