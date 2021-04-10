using System.Text;

namespace Elements.BodyElements
{
    public class Input : HTMLBodyElement
    {
        internal Input(string type, HTMLBodyElement parent)
            : base("input", parent)
        {
            Attributes.Add("type", type);
        }
    }
}