using System.Text;

namespace SharpTemplar.Shared
{
    internal class HTMLString : HTMLElement
    {
        public string Content;

        internal HTMLString(string content)
            : base(null)
        {
            Content = content;
        }

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append(Content);
        }
    }
}