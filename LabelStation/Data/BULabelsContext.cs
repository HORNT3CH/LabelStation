using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class BULabelsContext : DbContext
    {
        public BULabelsContext (DbContextOptions<BULabelsContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.BULabel> BULabel { get; set; } = default!;
    }
}
