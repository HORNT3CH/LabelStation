using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class NameBadgesContext : DbContext
    {
        public NameBadgesContext (DbContextOptions<NameBadgesContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.NameBadge> NameBadge { get; set; } = default!;
    }
}
