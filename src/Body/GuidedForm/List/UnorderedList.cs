
namespace SharpTemplar.GuidedForm.ListElements
{
    public class UnorderedList : HTMLListElement
    {
        internal override string TagType => "ul";
        internal UnorderedList(HTMLBodyElement parent)
            : base(parent) {}
    }
}