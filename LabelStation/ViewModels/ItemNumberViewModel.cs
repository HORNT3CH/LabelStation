using LabelStation.Models;

namespace LabelStation.ViewModels
{
    public class ItemNumberViewModel
    {
        public IEnumerable<ItemNumber>? ItemNumbers { get; set; }

        public BULabel BULabel { get; set; }
    }
}
