using System.Text;

namespace Elements.BodyElements
{
    public class Anchor : HTMLBodyElement
    {
        internal Anchor(string href) 
        {
            tagType = "a";
            Attributes.Add("href", href);
        }
    }
}