using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class JlabelContext : DbContext
    {
        public JlabelContext (DbContextOptions<JlabelContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.Jlabel> Jlabel { get; set; } = default!;
    }
}
