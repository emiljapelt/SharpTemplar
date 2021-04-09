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
        internal HTMLBodyElement UnderConstruction;

        protected HTMLBodyElement()
        {
            Contains = new List<HTMLBodyElement>();
            Attributes = new Dictionary<string, string>();
            Newest = this;
            UnderConstruction = null;
        }

        internal virtual void ConstructElement(StringBuilder sb)
        {
            FinishConstruction();
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
            FinishConstruction();
            UnderConstruction = e;
            return this;
        }

        private void FinishConstruction()
        {
            if (UnderConstruction is null) return;
            var element = UnderConstruction;
            UnderConstruction = null;
            Contains.Add(element);
            Newest = element;
        }

        /// <summary>
        /// Navigates to the ParentElement.
        /// </summary>
        /// <returns>
        /// Parent of the Element it is called on.
        /// </returns>
        public HTMLBodyElement ToParent()
        {
            FinishConstruction();
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
            FinishConstruction();
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
            if (UnderConstruction.Attributes.ContainsKey(key)) UnderConstruction.Attributes[key] = $"{Attributes[key]} {value}";
            UnderConstruction.Attributes.Add(key, value);
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
            return AddElement(p);
        }
        public HTMLBodyElement AddParagraph(string content, out HTMLBodyElement saveIn)
        {
            var p = new Paragraph(content, this);
            saveIn = p;
            return AddElement(p);
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
            return AddElement(a);
        }
        public HTMLBodyElement AddAnchor(string href, out HTMLBodyElement saveIn)
        {           
            var a = new Anchor(href, this);
            saveIn = a;
            return AddElement(a);
        }

        /// <summary>
        /// Adds text into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement InsertHTMLString(string content)
        {
            FinishConstruction();
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
            FinishConstruction();
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
        public HTMLBodyElement AddDiv(out HTMLBodyElement saveIn)
        {
            var div = new Div(this);
            saveIn = div;
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
        public HTMLBodyElement AddForm(out HTMLBodyElement saveIn)
        {
            var form = new Form(this);
            saveIn = form;
            return AddElement(form);
        }
    }
}