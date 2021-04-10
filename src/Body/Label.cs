using System.Text;
using Elements.Shared;

namespace Elements.BodyElements
{
    public class Label : HTMLBodyElement
    {
        internal Label(string content, HTMLBodyElement parent)
            : base("label", parent)
        {
            Contains.Add(new HTMLBodyString(content));
        }
    }
}