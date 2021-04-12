using System.Text;

namespace Elements.Shared
{
    internal class HTMLString : HTMLElement
    {
        public string Content;

        internal HTMLString(string content)
            : base(null, null)
        {
            Content = content;
        }

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append(Content);
        }
    }
}