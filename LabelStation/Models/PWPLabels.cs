using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace LabelStation.Models
{
    public class PWPLabels
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? ItemNumber { get; set; }
        [Required]        
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        
        public DateTime? ProductionDate { get; set; }
        
        [Required]
        public string? CodePartA { get; set; }

        [Required]
        public string? CodePartB { get; set; }

        [Required]
        public string? CodePartC { get; set; }

        [Required]
        public string? Shift { get; set; }

        [Required]
        public int? PrintQty { get; set; }

        [Required]
        public string? MachineNumber { get; set; }

        [Required]
        public string? PrinterName { get; set; }
    }
}
