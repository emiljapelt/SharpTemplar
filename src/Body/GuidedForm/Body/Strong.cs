using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.BodyElements
{
    public class Strong : HTMLBodyElement
    {
        internal override string TagType => "strong";
        internal Strong(string content, HTMLElement parent)
            : base(parent)
        {
            Contains.Add(new HTMLString(content));
        }

        internal Strong(HTMLElement parent)
            : base(parent) { }
    }
}