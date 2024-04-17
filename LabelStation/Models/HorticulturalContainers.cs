using Microsoft.Build.Framework;
using System.ComponentModel;

namespace LabelStation.Models
{
    public class HorticulturalContainers
    {
        public int Id { get; set; }
        [DisplayName("Little Tikes Part Number")]
        [Required]
        public string LTPartNumber { get; set; }
        [DisplayName("Customer Part Number")]
        public string? CustomerPartNumber { get; set; }
        public string? Description { get; set; }
        public string? Barcode { get; set; }
        [DisplayName("Pack Amount")]
        public int? PackAmount { get; set; }
        public int? Quantity { get; set; }
        public string? Print { get; set; }
    }
}
