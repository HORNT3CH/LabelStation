#nullable disable

using System.ComponentModel;

namespace LabelStation.Models
{
	public class NameBadge
	{
		public int ID { get; set; }
		[DisplayName("Full Name")]
		public string PrintName { get; set; }
		[DisplayName("User Name")]
		public string HJUser { get; set; }
		[DisplayName("Printer Name")]
		public string PrinterName { get; set; }
	}
}
