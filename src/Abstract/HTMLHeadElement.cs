using Elements.HeadElements;
using System.Collections.Generic;
using System.Text;

namespace Elements
{
    public abstract class HTMLHeadElement : HTMLElement
    {
        internal List<HTMLHeadElement> Contains;
        internal Dictionary<string, string> Attributes;

        protected HTMLHeadElement()
        {
            Contains = new List<HTMLHeadElement>();
            Attributes = new Dictionary<string, string>();
        }

        internal virtual void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<{tagType}");
            foreach(var a in Attributes)
            {
                sb.Append($" {a.Key}=\"{a.Value}\"");
            }
            sb.Append(">");
            foreach(HTMLHeadElement e in Contains)
            {
                e.ConstructElement(sb);
            }
            sb.Append($"</{tagType}>");
        }

        public HTMLHeadElement AddStyleSheet(string path)
        {
            Contains.Add(new Style(path));
            return this;
        }
    }
}