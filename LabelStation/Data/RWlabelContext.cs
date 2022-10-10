using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class RWlabelContext : DbContext
    {
        public RWlabelContext (DbContextOptions<RWlabelContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.RWlabel> RWlabel { get; set; } = default!;
    }
}
