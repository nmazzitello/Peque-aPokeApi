using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using pokeApi.Models;

namespace pokeApi.Data
{
    public class pokeApiContext : DbContext
    {
        public pokeApiContext (DbContextOptions<pokeApiContext> options)
            : base(options)
        {
        }

        public DbSet<pokeApi.Models.Tipo> Tipo { get; set; } = default!;

        public DbSet<pokeApi.Models.Pokemon>? Pokemon { get; set; }
    }
}
