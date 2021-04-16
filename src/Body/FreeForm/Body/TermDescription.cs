
namespace SharpTemplar.FreeForm.BodyElements
{
    public class TermDescription : HTMLBodyElement
    {
        internal override string TagType => "dd";
        internal TermDescription(HTMLBodyElement parent)
            : base(parent) { }
    }
}