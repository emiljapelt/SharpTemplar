using Elements.HeadElements;
using System.Collections.Generic;
using System.Text;

namespace Elements
{
    public abstract class HTMLHeadElement : HTMLElement
    {
        internal List<HTMLHeadElement> Contains;

        protected HTMLHeadElement()
        {
            Contains = new List<HTMLHeadElement>();
        }

        internal virtual void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<{tagType}>");
            foreach(HTMLHeadElement e in Contains)
            {
                e.ConstructElement(sb);
            }
            sb.Append($"</{tagType}>");
        }
    }
}