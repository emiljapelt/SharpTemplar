using System.Text;

namespace SharpTemplar.Shared
{
    public class Break : HTMLBodyElement
    {
        internal Break()
            : base("br", null) { }

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<{TagType}>");
        }
    }
}