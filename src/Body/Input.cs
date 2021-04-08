using System.Text;

namespace Elements.BodyElements
{
    public class Input : HTMLBodyElement
    {
        internal Input(string type, HTMLBodyElement parent) 
        {
            tagType = "input";
            Attributes.Add("type", type);
            Parent = parent;
        }
    }
}