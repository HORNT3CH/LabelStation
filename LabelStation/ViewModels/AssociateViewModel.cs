using LabelStation.Models;

namespace LabelStation.ViewModels
{
    public class AssociateViewModel
    {
        public IEnumerable<Associates>? Associates { get; set; }

        public PWPLabels? PWPLabels { get; set; }
    }
}
