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

        /// <summary>
        /// Navigates to the ParentElement.
        /// </summary>
        /// <returns>
        /// Parent of Element it is called on.
        /// </returns>
        public HTMLBodyElement ToParent()
        {
            return Parent;
        }

        /// <summary>
        /// Adds attribute of any kind to the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement WithAttribute(string key, string value)
        {
            if (Attributes.ContainsKey(key)) Attributes[key] = $"{Attributes[key]} {value}";
            Attributes.Add(key, value);
            return this;
        }

        /// <summary>
        /// Adds many attributes of any kind to the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement WithAttributes(params (string key, string value)[] list)
        {
            foreach(var a in list)
            {
                WithAttribute(a.key, a.value);
            }
            return this;
        }
        
        /// <summary>
        /// Adds class attribute to the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement WithClass(string value)
        {
            return WithAttribute("class", value);
        }

        /// <summary>
        /// Adds style attribute to the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement WithStyle(string value)
        {
            return WithAttribute("style", value);
        }

        /// <summary>
        /// Adds Paragraph into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The added Paragraph.
        /// </returns>
        public Paragraph AddParagraph(string content)
        {
            var p = new Paragraph(content, this);
            Contains.Add(p);
            return p;
        }

        /// <summary>
        /// Adds Anchor into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The added Anchor.
        /// </returns>
        public Anchor AddAnchor(string href)
        {
            var a = new Anchor(href, this);
            Contains.Add(a);
            return a;
        }

        /// <summary>
        /// Adds text into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddHTMLString(string content)
        {
            Contains.Add(new HTMLBodyString(content));
            return this;
        }

        /// <summary>
        /// Adds Div into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The added Div.
        /// </returns>
        public Div AddDiv()
        {
            var div = new Div(this);
            Contains.Add(div);
            return div;
        }
    }
}