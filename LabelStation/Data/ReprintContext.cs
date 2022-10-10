using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class ReprintContext : DbContext
    {
        public ReprintContext (DbContextOptions<ReprintContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.Reprint> Reprint { get; set; } = default!;
    }
}
