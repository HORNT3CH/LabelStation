using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class PlabelContext : DbContext
    {
        public PlabelContext (DbContextOptions<PlabelContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.Plabel> Plabel { get; set; } = default!;
    }
}
