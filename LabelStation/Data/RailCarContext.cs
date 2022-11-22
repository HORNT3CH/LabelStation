using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class RailCarContext : DbContext
    {
        public RailCarContext (DbContextOptions<RailCarContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.RailCar> RailCar { get; set; } = default!;
    }
}
