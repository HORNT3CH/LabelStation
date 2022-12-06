namespace LabelStation.Models
{
    public class BULabel
    {
        public int ID { get; set; }

        public string? ItemNumber { get; set; }

        public string? ItemDescription { get; set; }

        public string? Print { get; set; }

        public int Standard { get; set; }

        public int Quantity { get; set; }

        public int LPNumber { get; set; }

        public string? IsReprint { get; set; }

        public string? Prefix { get; set; }

        public string? PrinterName { get; set; }

    }
}
