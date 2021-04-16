using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.FormElements
{
    public class Label : HTMLFormElement
    {
        internal Label(string _refTo, string content, HTMLElement parent)
            : base("label", parent)
        {
            Contains.Add(new HTMLString(content));
            Attributes.Add("for", _refTo);
        }
    }
}