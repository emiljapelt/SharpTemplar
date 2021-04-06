using System.Text;

namespace Elements.BodyElements
{
    public class Anchor : HTMLBodyElement
    {
        internal Anchor(string href, HTMLBodyElement parent) 
        {
            tagType = "a";
            Parent = parent;
            Attributes.Add("href", href);
        }
    }
}