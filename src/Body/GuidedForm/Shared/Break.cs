using System.Text;

namespace SharpTemplar.GuidedForm.Shared
{
    public class Break : HTMLBodyElement
    {
        internal override string TagType => "br";
        internal Break()
            : base(null) { }

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<{TagType}>");
        }
    }
}