using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class WlabelContext : DbContext
    {
        public WlabelContext (DbContextOptions<WlabelContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.Wlabel> Wlabel { get; set; } = default!;
    }
}
