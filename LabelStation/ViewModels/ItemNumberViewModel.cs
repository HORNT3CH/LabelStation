using LabelStation.Models;

namespace LabelStation.ViewModels
{
    public class ItemNumberViewModel
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public IEnumerable<ItemNumber> ItemNumbers { get; set; }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        public PWPLabels? PWPLabels { get; set; }
    }
}
