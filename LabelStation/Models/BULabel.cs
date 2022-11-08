namespace LabelStation.Models
{
    public class BULabel
    {
        public int ID { get; set; }

        public byte Print { get; set; }

        public string? Item { get; set; }

        public string? ItemDesc { get; set; }

        public int Quantity { get; set; }

        public int Standard { get; set; }

    }
}
