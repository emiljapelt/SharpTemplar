
namespace SharpTemplar.FreeForm.BodyElements
{
    public class Term : HTMLBodyElement
    {
        internal override string TagType => "dt";
        internal Term(HTMLBodyElement parent)
            : base(parent) { }
    }
}