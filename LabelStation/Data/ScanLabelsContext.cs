using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class ScanLabelsContext : DbContext
    {
        public ScanLabelsContext (DbContextOptions<ScanLabelsContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.ScanLabel> ScanLabel { get; set; } = default!;

        public DbSet<LabelStation.Models.ItemNumber> ItemNumber { get; set; } = default!;
    }
}
