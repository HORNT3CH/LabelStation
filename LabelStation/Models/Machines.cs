using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LabelStation.Models
{
    public class Machines
    {
        [Key]
        public int ID { get; set; }
        [DisplayName("Machine Department")]
        public string? MachineDepartment { get; set; }
        [DisplayName("Machine Name")]
        public string? MachineNumber { get; set; }
    }
}
