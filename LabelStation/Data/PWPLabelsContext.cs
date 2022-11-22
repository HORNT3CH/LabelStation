using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class PWPLabelsContext : DbContext
    {
        public PWPLabelsContext (DbContextOptions<PWPLabelsContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.PWPLabels> PWPLabels { get; set; } = default!;

        public DbSet<LabelStation.Models.ItemNumber> ItemNumber { get; set; } = default!;

        public DbSet<LabelStation.Models.Associates> Associates { get; set; } = default!;
    }
}
