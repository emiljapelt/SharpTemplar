using System.Text;

namespace Elements.Shared
{
    internal class HTMLString : HTMLHeadElement
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