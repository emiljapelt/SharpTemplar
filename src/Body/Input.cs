using System.Text;

namespace Elements.BodyElements
{
    public class Input : HTMLBodyElement
    {
        internal Input(HTMLBodyElement parent) 
        {
            tagType = "input";
            Parent = parent;
        }
    }
}