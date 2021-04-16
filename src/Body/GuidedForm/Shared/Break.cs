using System.Text;

namespace SharpTemplar.GuidedForm.Shared
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