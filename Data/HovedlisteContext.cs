using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hovedliste.Models;
using Microsoft.EntityFrameworkCore;

namespace Hovedliste.Data
{
    public class HovedlisteContext:DbContext
    {
        public HovedlisteContext(DbContextOptions<HovedlisteContext> options)
            : base(options)
        {
        }
        public DbSet<Sager> Sager { get; set; }
    }

}
