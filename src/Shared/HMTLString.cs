using System.Text;

namespace Elements.Shared
{
    internal class HTMLHeadString : HTMLHeadElement
    {
        public string Content;

        internal HTMLHeadString(string content)
            : base(null)
        {
            Content = content;
        }

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append(Content);
        }
    }

    internal class HTMLBodyString : HTMLBodyElement
    {
        public string Content;

        internal HTMLBodyString(string content)
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