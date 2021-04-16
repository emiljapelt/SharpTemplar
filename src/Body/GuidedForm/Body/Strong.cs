using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.BodyElements
{
    public class Strong : HTMLBodyElement
    {

        internal Strong(string content, HTMLElement parent)
            : base("strong", parent)
        {
            Contains.Add(new HTMLString(content));
        }

        internal Strong(HTMLElement parent)
            : base("strong", parent) { }
    }
}