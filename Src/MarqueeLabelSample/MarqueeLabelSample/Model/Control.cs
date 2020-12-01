using Xamarin.Forms.Internals;

namespace MarqueeLabelSample.Model
{
    [Preserve(AllMembers = true)]
    public class Control
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string PriorityId { get; set; }
        public string PreviewImage { get; set; }
    }
}
