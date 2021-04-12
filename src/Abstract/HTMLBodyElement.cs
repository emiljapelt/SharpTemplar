using Elements.BodyElements;
using Elements.TableElements;
using Elements.FormElements;
using Elements.Shared;

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
        private HTMLElement _Newest;
        internal override HTMLElement Newest 
        { 
            get { return _Newest; }
            set { _Newest = value; }
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
            return (HTMLBodyElement) _Newest;
        }

        /// <summary>
        /// Adds attribute of any kind to the Element it is called on. If the Element already has the attribute, the new attribute is appended to the old attribute with a single space.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public virtual HTMLBodyElement WithAttribute(string key, string value)
        {
            AddAttribute(key, value);
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
            AddAttributes(list);
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
        public HTMLBodyElement AddParagraph(out HTMLBodyElement saveIn, string content)
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
        public HTMLBodyElement AddAnchor(out HTMLBodyElement saveIn, string href)
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
            Contains.Add(new HTMLString(content));
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
            Contains.Add(new Break());
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
        /// Adds Lable into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddLabel(string form, string refTo, string content)
        {
            var label = new Label(refTo, content, this);
            label.WithAttribute("form", form);
            AddElement(label);
            return this;
        }
/*
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
*/
        public HTMLTableElement BeginTable(params string[] columns)
        {
            var table = new Table(this, columns);
            AddElement(table);
            return table;
        }
        public HTMLTableElement BeginTable(out HTMLTableElement saveIn, params string[] columns)
        {
            var table = new Table(this, columns);
            saveIn = table;
            AddElement(table);
            return table;
        }

        public HTMLTableElement BeginTable()
        {
            var table = new Table(this);
            AddElement(table);
            return table;
        }
        public HTMLTableElement BeginTable(out HTMLTableElement saveIn)
        {
            var table = new Table(this);
            saveIn = table;
            AddElement(table);
            return table;
        }

        public HTMLFormElement BeginForm(string id)
        {
            var form = new Form(this, id);
            AddElement(form);
            return form;
        }
        public HTMLFormElement BeginForm(out HTMLFormElement saveIn, string id)
        {
            var form = new Form(this, id);
            AddElement(form);
            saveIn = form;
            return form;
        }
    }
}