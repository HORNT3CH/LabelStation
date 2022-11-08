using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class AssociatesContext : DbContext
    {
        public AssociatesContext (DbContextOptions<AssociatesContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.Associates> Associates { get; set; } = default!;
    }
}
