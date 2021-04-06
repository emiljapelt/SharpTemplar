using Elements.BodyElements;
using Elements.Shared;
using System.Collections.Generic;
using System.Text;

namespace Elements
{
    public abstract class HTMLBodyElement : HTMLElement
    {
        internal List<HTMLBodyElement> Contains;
        internal Dictionary<string, string> Attributes;
        internal HTMLBodyElement Parent;

        protected HTMLBodyElement()
        {
            Contains = new List<HTMLBodyElement>();
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
            foreach(HTMLBodyElement e in Contains)
            {
                e.ConstructElement(sb);
            }
            sb.Append($"</{tagType}>");
        }

        internal void SetParent(HTMLBodyElement parent)
        {
            Parent = parent;
        }

        public HTMLBodyElement ToParent()
        {
            return Parent;
        }

        public HTMLBodyElement WithAttribute(string key, string value)
        {
            if (Attributes.ContainsKey(key)) Attributes[key] = $"{Attributes[key]} {value}";
            Attributes.Add(key, value);
            return this;
        }

        public HTMLBodyElement WithAttributes(params (string key, string value)[] list)
        {
            foreach(var a in list)
            {
                WithAttribute(a.key, a.value);
            }
            return this;
        }
        
        public HTMLBodyElement WithClass(string value)
        {
            return WithAttribute("class", value);
        }

        public HTMLBodyElement WithStyle(string value)
        {
            return WithAttribute("style", value);
        }

        public Paragraph AddParagraph(string content)
        {
            var p = new Paragraph(content, this);
            Contains.Add(p);
            return p;
        }

        public Anchor AddAnchor(string href)
        {
            var a = new Anchor(href, this);
            Contains.Add(a);
            return a;
        }

        public HTMLBodyElement AddHTMLString(string content)
        {
            Contains.Add(new HTMLBodyString(content));
            return this;
        }

        public Div AddDiv()
        {
            var div = new Div(this);
            Contains.Add(div);
            return div;
        }
    }
}