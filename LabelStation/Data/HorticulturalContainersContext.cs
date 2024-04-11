using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class HorticulturalContainersContext : DbContext
    {
        public HorticulturalContainersContext (DbContextOptions<HorticulturalContainersContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.HorticulturalContainers> HorticulturalContainers { get; set; } = default!;
    }
}
