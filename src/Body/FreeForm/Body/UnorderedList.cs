
namespace SharpTemplar.FreeForm.BodyElements
{
    public class UnorderedList : HTMLBodyElement
    {
        internal override string TagType => "ul";
        internal UnorderedList(HTMLBodyElement parent)
            : base(parent) { }
    }
}