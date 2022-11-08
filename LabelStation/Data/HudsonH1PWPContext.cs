using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class HudsonH1PWPContext : DbContext
    {
        public HudsonH1PWPContext (DbContextOptions<HudsonH1PWPContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.HudsonH1PWP> HudsonH1PWP { get; set; } = default!;
    }
}
