using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class SkuCardsContext : DbContext
    {
        public SkuCardsContext (DbContextOptions<SkuCardsContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.SkuCard> SkuCard { get; set; } = default!;

        public DbSet<LabelStation.Models.ItemNumber> ItemNumber { get; set; } = default!;
    }
}
