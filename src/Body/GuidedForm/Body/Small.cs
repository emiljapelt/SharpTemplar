using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.BodyElements
{
    public class Small : HTMLBodyElement
    {
        internal override string TagType => "small";

        internal Small(string content, HTMLElement parent)
            : base(parent)
        {
            Contains.Add(new HTMLString(content));
        }
    }
}