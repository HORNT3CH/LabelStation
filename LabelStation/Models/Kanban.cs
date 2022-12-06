#nullable disable


namespace LabelStation.Models
{
    public class Kanban
    {
        public int ID { get; set; }

        public string Print { get; set; }

        public string BOMID { get; set; }

        public string ItemNumber { get; set; }

        public string ItemDescription { get; set; }

        public int PrintQty { get; set; }

        public string FullName { get; set; }

        public string MachineNumber { get; set; }

        public int ReOrderQty { get; set; }

        public int OrderQty { get; set; }

        public int LineLimit { get; set; }

        public string ParentSKU { get; set; }

        public string ParentDescription { get; set; }

        public string PrinterName { get; set; }
    }
}
