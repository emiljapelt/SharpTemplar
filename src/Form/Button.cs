using SharpTemplar.Shared;

namespace SharpTemplar.FormElements
{
    public class Button : HTMLFormElement
    {
        internal Button(string type, string text, HTMLElement parent)
            : base("button", parent)
        {
            Attributes.Add("type", type);
            Contains.Add(new HTMLString(text));
        }
    }
}