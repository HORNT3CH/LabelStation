#nullable disable
namespace LabelStation.Models
{
    public class ScanLabel
    {
        public int ScanLabelId { get; set; }

        public string ItemNumber { get; set; }

        public string ItemDescription { get; set; }

        public string PrintLabel { get; set; }

        public string ImageLocation { get; set; }
        public string CarryHeight { get; set; }
        public string StackHeight { get; set; }
    }
}
