#nullable disable
using Microsoft.Build.Framework;

namespace LabelStation.Models
{
    public class Associates
    {
        public int ID { get; set; }
        [Required]
        public string FullName { get; set; }

    }
}
