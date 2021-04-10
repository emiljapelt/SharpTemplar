using System.Text;

namespace Elements.BodyElements
{
    public class Break : HTMLBodyElement
    {
        internal Break(HTMLBodyElement parent)
            : base("br", parent) { }

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<{TagType}>");
        }
    }
}