using System.Text;
using Elements.Shared;

namespace Elements.BodyElements
{
    public class Button : HTMLBodyElement
    {
        internal Button(string type, string text, HTMLBodyElement parent)
            : base("button", parent)
        {
            Attributes.Add("type", type);
            Contains.Add(new HTMLBodyString(text));
        }
    }
}