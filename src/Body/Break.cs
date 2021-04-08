using System.Text;

namespace Elements.BodyElements
{
    public class Break : HTMLBodyElement
    {
        internal Break(HTMLBodyElement parent) 
        {
            tagType = "br";
            Parent = parent;
        }

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<{tagType}>");
        }
    }
}