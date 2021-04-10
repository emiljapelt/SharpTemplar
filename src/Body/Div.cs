using System.Text;

namespace Elements.BodyElements
{
    public class Div : HTMLBodyElement
    {
        internal Div(HTMLBodyElement parent)
                : base("div", parent) { }
    }
}