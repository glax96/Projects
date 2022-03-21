using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutomobiliEvidencija.Models
{
    public class AutomobiliEvidencijaContext : DbContext
    {
        public AutomobiliEvidencijaContext (DbContextOptions<AutomobiliEvidencijaContext> options)
            : base(options)
        {
        }

        public DbSet<AutomobiliEvidencija.Models.Automobil> Automobil { get; set; }
    }
}
