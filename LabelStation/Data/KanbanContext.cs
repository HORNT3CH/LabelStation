using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LabelStation.Models;

namespace LabelStation.Data
{
    public class KanbanContext : DbContext
    {
        public KanbanContext (DbContextOptions<KanbanContext> options)
            : base(options)
        {
        }

        public DbSet<LabelStation.Models.Kanban> Kanban { get; set; } = default!;
    }
}
