using Elements.BodyElements;
using Elements.Shared;
using System.Collections.Generic;
using System.Text;

namespace Elements
{
    public abstract class HTMLBodyElement : HTMLElement
    {
        private HTMLBodyElement _Parent;
        internal override HTMLElement Parent 
        { 
            get { return _Parent; }
            set { _Parent = (HTMLBodyElement) value; }
        }
        private HTMLBodyElement _Newest;
        internal override HTMLElement Newest 
        { 
            get { return _Newest; }
            set { _Newest = (HTMLBodyElement) value; }
        }


        protected HTMLBodyElement(string tagType, HTMLBodyElement parent)
            : base(tagType, parent) { }


        /// <summary>
        /// Navigates to the Parent Element.
        /// </summary>
        /// <returns>
        /// Parent of the Element it is called on.
        /// </returns>
        public HTMLBodyElement ToParent()
        {
            FinishConstruction();
            return _Parent;
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
            return _Newest;
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
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddParagraph(string content)
        {
            var p = new Paragraph(content, this);
            AddElement(p);
            return this;
        }
        public HTMLBodyElement AddParagraph(string content, out HTMLBodyElement saveIn)
        {
            var p = new Paragraph(content, this);
            saveIn = p;
            AddElement(p);
            return this;
        }

        /// <summary>
        /// Adds Anchor into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddAnchor(string href)
        {           
            var a = new Anchor(href, this);
            AddElement(a);
            return this;
        }
        public HTMLBodyElement AddAnchor(string href, out HTMLBodyElement saveIn)
        {           
            var a = new Anchor(href, this);
            saveIn = a;
            AddElement(a);
            return this;
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
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddDiv()
        {
            var div = new Div(this);
            AddElement(div);
            return this;
        }
        public HTMLBodyElement AddDiv(out HTMLBodyElement saveIn)
        {
            var div = new Div(this);
            saveIn = div;
            AddElement(div);
            return this;
        }

        /// <summary>
        /// Adds Form into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddForm()
        {
            var form = new Form(this);
            AddElement(form);
            return this;
        }
        public HTMLBodyElement AddForm(out HTMLBodyElement saveIn)
        {
            var form = new Form(this);
            saveIn = form;
            AddElement(form);
            return this;
        }

        /// <summary>
        /// Adds Lable into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddLabel(string content)
        {
            var label = new Label(content, this);
            AddElement(label);
            return this;
        }
        public HTMLBodyElement AddLabel(string content, out HTMLBodyElement saveIn)
        {
            var label = new Label(content, this);
            saveIn = label;
            AddElement(label);
            return this;
        }

        /// <summary>
        /// Adds Input into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddInput(string type)
        {
            var input = new Input(type, this);
            AddElement(input);
            return this;
        }
        public HTMLBodyElement AddInput(string type, out HTMLBodyElement saveIn)
        {
            var input = new Input(type, this);
            saveIn = input;
            AddElement(input);
            return this;
        }

        /// <summary>
        /// Adds Button into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddButton(string type, string text)
        {
            var button = new Button(type, text, this);
            AddElement(button);
            return this;
        }
        public HTMLBodyElement AddInput(string type, string text, out HTMLBodyElement saveIn)
        {
            var button = new Button(type, text, this);
            saveIn = button;
            AddElement(button);
            return this;
        }
    }
}