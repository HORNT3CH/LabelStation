using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class ItemContext : DbContext
    {
        public ItemContext (DbContextOptions<ItemContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.ItemNumber> ItemNumber { get; set; } = default!;

        public DbSet<LabelStation.Models.ItemNumber> ItemDesc { get; set; } = default!;
    }
}
