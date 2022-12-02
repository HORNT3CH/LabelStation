using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class FlowerPotsContext : DbContext
    {
        public FlowerPotsContext (DbContextOptions<FlowerPotsContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.FlowerPots> FlowerPots { get; set; } = default!;
    }
}
