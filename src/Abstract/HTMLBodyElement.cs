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
        internal HTMLBodyElement Newest;

        protected HTMLBodyElement()
        {
            Contains = new List<HTMLBodyElement>();
            Attributes = new Dictionary<string, string>();
            Newest = this;
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

        private HTMLBodyElement AddElement(HTMLBodyElement e)
        {
            Contains.Add(e);
            Newest = e;
            return this;
        }

        /// <summary>
        /// Navigates to the ParentElement.
        /// </summary>
        /// <returns>
        /// Parent of the Element it is called on.
        /// </returns>
        public HTMLBodyElement ToParent()
        {
            return Parent;
        }

        /// <summary>
        /// Navigates to the newest added element.
        /// </summary>
        /// <returns>
        /// Most recently added Element.
        /// </returns>
        public HTMLBodyElement EnterIt()
        {
            return Newest;
        }

        /// <summary>
        /// Adds attribute of any kind to the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public virtual HTMLBodyElement WithAttribute(string key, string value)
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
        public virtual  HTMLBodyElement WithAttributes(params (string key, string value)[] list)
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
        public HTMLBodyElement AddParagraph(string content)
        {
            var p = new Paragraph(content, this);
            Contains.Add(p);
            Newest = p;
            return this;
        }

        /// <summary>
        /// Adds Anchor into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The added Anchor.
        /// </returns>
        public HTMLBodyElement AddAnchor(string href)
        {
            var a = new Anchor(href, this);
            Contains.Add(a);
            Newest = a;
            return this;
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
        /// Adds break into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public virtual HTMLBodyElement AddBreak()
        {
            Contains.Add(new Break(this));
            return this;
        }

        /// <summary>
        /// Adds Div into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The added Div.
        /// </returns>
        public HTMLBodyElement AddDiv()
        {
            var div = new Div(this);
            return AddElement(div);
        }
        public HTMLBodyElement AddDiv(out HTMLBodyElement self)
        {
            var div = new Div(this);
            self = div;
            return AddElement(div);
        }

        /// <summary>
        /// Adds Form into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The added Form.
        /// </returns>
        public HTMLBodyElement AddForm()
        {
            var form = new Form(this);
            return AddElement(form);
        }
        public HTMLBodyElement AddForm(out HTMLBodyElement self)
        {
            var form = new Form(this);
            self = form;
            return AddElement(form);
        }
    }
}