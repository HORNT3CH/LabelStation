using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class HLabelContext : DbContext
    {
        public HLabelContext (DbContextOptions<HLabelContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.Hlabel> Hlabel { get; set; } = default!;
    }
}
