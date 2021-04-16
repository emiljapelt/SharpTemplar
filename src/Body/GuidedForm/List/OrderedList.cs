
namespace SharpTemplar.GuidedForm.ListElements
{
    public class OrderedList : HTMLListElement
    {
        internal override string TagType => "ol";
        internal OrderedList(HTMLBodyElement parent)
            : base(parent) {}
    }
}