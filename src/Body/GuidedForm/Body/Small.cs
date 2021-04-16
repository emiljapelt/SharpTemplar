using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.BodyElements
{
    public class Small : HTMLBodyElement
    {

        internal Small(string content, HTMLElement parent)
            : base("small", parent)
        {
            Contains.Add(new HTMLString(content));
        }
    }
}