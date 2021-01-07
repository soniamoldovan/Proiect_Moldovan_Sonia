using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Moldovan_Sonia.Models;

namespace Proiect_Moldovan_Sonia.Data
{
    public class Proiect_Moldovan_SoniaContext : DbContext
    {
        public Proiect_Moldovan_SoniaContext (DbContextOptions<Proiect_Moldovan_SoniaContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Moldovan_Sonia.Models.Painting> Painting { get; set; }

        public DbSet<Proiect_Moldovan_Sonia.Models.Museum> Museum { get; set; }

        public DbSet<Proiect_Moldovan_Sonia.Models.Era> Era { get; set; }
    }
}
