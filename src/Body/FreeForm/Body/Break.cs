using System.Text;

namespace SharpTemplar.FreeForm
{
    public class Break : HTMLBodyElement
    {
        internal override string TagType => "br";
        internal Break()
            : base (null) {}

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<{TagType}>");
        }
    }

    public abstract partial class HTMLBodyElement : HTMLElement
    {
        /// <summary>
        /// Adds break into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public virtual HTMLBodyElement AddBreak()
        {
            ResetThisElement();
            Contains.Add(new Break());
            return this;
        }
    }
}