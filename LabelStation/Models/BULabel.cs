namespace LabelStation.Models
{
    public class BULabel
    {
        public int ID { get; set; }

        public byte Print { get; set; }

        public string? ItemNumber { get; set; }

        public string? ItemDescription { get; set; }

        public int Quantity { get; set; }

        public int Standard { get; set; }

    }
}
