#nullable disable
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace LabelStation.Models
{
    public class Kanban
    {
        [Key]
        public int ID { get; set; }

        [Required, NotNull]
        public string Print { get; set; }

        [Required, NotNull]
        public string BOMID { get; set; }
        [Required, NotNull]
        public string ItemNumber { get; set; }

        [Required, NotNull]
        public string ItemDescription { get; set; }

        [Required, NotNull]
        public int PrintQty { get; set; }

        [Required, NotNull]
        public string FullName { get; set; }

        [Required, NotNull]
        public string MachineNumber { get; set; }

        [Required, NotNull]
        public int ReOrderQty { get; set; }

        [Required, NotNull]
        public int OrderQty { get; set; }

        [Required, NotNull]
        public int LineLimit { get; set; }

        [Required, NotNull]
        public string ParentSKU { get; set; }

        [Required, NotNull]
        public string ParentDescription { get; set; }

        [Required]
        public string PrinterName { get; set; }
    }
}
