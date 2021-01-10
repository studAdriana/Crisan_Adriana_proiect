using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Crisan_Adriana_proiect.Models;

namespace Crisan_Adriana_proiect.Data
{
    public class Crisan_Adriana_proiectContext : DbContext
    {
        public Crisan_Adriana_proiectContext (DbContextOptions<Crisan_Adriana_proiectContext> options)
            : base(options)
        {
        }

        public DbSet<Crisan_Adriana_proiect.Models.Toy> Toy { get; set; }

        public DbSet<Crisan_Adriana_proiect.Models.Category> Category { get; set; }

        public DbSet<Crisan_Adriana_proiect.Models.Seller> Seller { get; set; }
    }
}
