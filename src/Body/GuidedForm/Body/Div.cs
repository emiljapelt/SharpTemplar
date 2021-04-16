
namespace SharpTemplar.GuidedForm.BodyElements
{
    public class Div : HTMLBodyElement
    {
        internal override string TagType => "div";
        internal Div(HTMLBodyElement parent)
                : base(parent) { }
    }
}