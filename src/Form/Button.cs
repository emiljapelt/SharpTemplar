using System.Text;
using Elements.Shared;

namespace Elements.FormElements
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