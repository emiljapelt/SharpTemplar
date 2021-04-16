
namespace SharpTemplar.FreeForm.BodyElements
{
    public class OrderedList : HTMLBodyElement
    {
        internal override string TagType => "ol";
        internal OrderedList(HTMLBodyElement parent)
            : base(parent) { }
    }
}