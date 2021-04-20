
namespace SharpTemplar.FreeForm.BodyElements
{
    public class Span : HTMLBodyElement
    {
        internal override string TagType => "span";
        internal Span(HTMLBodyElement parent)
                : base(parent) { }
    }
}