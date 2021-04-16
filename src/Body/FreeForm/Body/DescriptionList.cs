
namespace SharpTemplar.FreeForm.BodyElements
{
    public class DescriptionList : HTMLBodyElement
    {
        internal override string TagType => "dl";
        internal DescriptionList(HTMLBodyElement parent)
            : base(parent) { }
    }
}