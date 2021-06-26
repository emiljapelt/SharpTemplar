using SharpTemplar.FreeForm.BodyElements;
using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm
{
    public abstract partial class HTMLBodyElement : HTMLElement
    {

        protected HTMLBodyElement(HTMLElement parent)
            : base(parent) { }


        /// <summary>
        /// Navigates to the Parent Element. For the Body element, the parent is itself.
        /// </summary>
        /// <returns>
        /// Parent of the Element it is called on.
        /// </returns>
        public virtual HTMLBodyElement Exit()
        {
            ResetThisElement();
            return (HTMLBodyElement) Parent;
        }

        /// <summary>
        /// Navigates to the newest added element. For Element where no Elements have been added, the newest element is itself.
        /// </summary>
        /// <returns>
        /// Most recently added Element.
        /// </returns>
        public HTMLBodyElement Enter()
        {
            var toEnter = Newest;
            ResetThisElement();
            return (HTMLBodyElement) toEnter;
        }

        /// <summary>
        /// Adds an attribute of any kind to the Element it is called on.
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
        /// Adds a class attribute to the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement WithClass(string value)
        {
            return WithAttribute("class", value);
        }

        public HTMLBodyElement WithClasses(params string[] values)
        {
            foreach (var c in values) WithClass(c);
            return this;
        }

        public HTMLBodyElement WithId(string value)
        {
            WithAttribute("id", value);
            return this;
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
        /// Adds text into the Element this is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddHTMLString(string content)
        {
            ResetThisElement();
            Contains.Add(new HTMLString(content));
            return this;
        }

        /// <summary>
        /// Adds text into the most recently added Element, in the Element this is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement InjectHTMLString(string content)
        {
            Newest.Contains.Add(new HTMLString(content));
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
            ResetThisElement();
            Contains.Add(new Break());
            return this;
        }
        
        /// <summary>
        /// Adds Paragraph into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddParagraph()
        {
            var p = new Paragraph(this);
            AddElement(p);
            return this;
        }
        public HTMLBodyElement AddParagraph(out HTMLBodyElement saveIn)
        {
            var p = new Paragraph(this);
            saveIn = p;
            AddElement(p);
            return this;
        }
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
        /// Adds Strong into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddStrong()
        {
            var strong = new Strong(this);
            AddElement(strong);
            return this;
        }
        public HTMLBodyElement AddStrong(out HTMLBodyElement saveIn)
        {
            var strong = new Strong(this);
            saveIn = strong;
            AddElement(strong);
            return this;
        }
        public HTMLBodyElement AddStrong(string text)
        {
            var strong = new Strong(text, this);
            AddElement(strong);
            return this;
        }
        public HTMLBodyElement AddStrong(out HTMLBodyElement saveIn, string text)
        {
            var strong = new Strong(text, this);
            saveIn = strong;
            AddElement(strong);
            return this;
        }

        /// <summary>
        /// Adds Small into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddSmall()
        {
            var small = new Small(this);
            AddElement(small);
            return this;
        }
        public HTMLBodyElement AddSmall(out HTMLBodyElement saveIn)
        {
            var small = new Small(this);
            saveIn = small;
            AddElement(small);
            return this;
        }
        public HTMLBodyElement AddSmall(string text)
        {
            var small = new Small(text, this);
            AddElement(small);
            return this;
        }
        public HTMLBodyElement AddSmall(out HTMLBodyElement saveIn, string text)
        {
            var small = new Small(text, this);
            saveIn = small;
            AddElement(small);
            return this;
        }

        /// <summary>
        /// Adds Header into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddHeader(HeaderLevel level, string content)
        {
            var h = new Header(level, content, this);
            AddElement(h);
            return this;
        }
        public HTMLBodyElement AddHeader(out HTMLBodyElement saveIn, HeaderLevel level, string content)
        {
            var h = new Header(level, content, this);
            saveIn = h;
            AddElement(h);
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
        /// Adds Image into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddImage(string src)
        {           
            var a = new Image(src, this);
            AddElement(a);
            return this;
        }
        public HTMLBodyElement AddImage(string src, string alt)
        {           
            var a = new Image(src, alt, this);
            AddElement(a);
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

        /// <summary>
        /// Adds Input into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddInput(string id, string type)
        {
            var input = new Input(id, type, this);
            AddElement(input);
            return this;
        }

        public HTMLBodyElement AddSelect(string name)
        {
            var select = new Select(name, this);
            AddElement(select);
            return this;
        }

        public HTMLBodyElement AddSelect(out HTMLBodyElement saveIn, string name)
        {
            var select = new Select(name, this);
            saveIn = select;
            AddElement(select);
            return this;
        }

        public HTMLBodyElement AddOption(string value)
        {
            var option = new Option(value, this);
            AddElement(option);
            return this;
        }

        public HTMLBodyElement AddOption(out HTMLBodyElement saveIn, string value)
        {
            var option = new Option(value, this);
            saveIn = option;
            AddElement(option);
            return this;
        }

        public HTMLBodyElement AddOption(string value, string text)
        {
            var option = new Option(value, text, this);
            AddElement(option);
            return this;
        }

        public HTMLBodyElement AddOption(out HTMLBodyElement saveIn, string value, string text)
        {
            var option = new Option(value, text, this);
            saveIn = option;
            AddElement(option);
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

        public HTMLBodyElement AddTable()
        {
            var table = new Table(this);
            AddElement(table);
            return this;
        }
        public HTMLBodyElement AddTable(out HTMLBodyElement saveIn)
        {
            var table = new Table(this);
            saveIn = table;
            AddElement(table);
            return this;
        }

        public HTMLBodyElement AddTableRow()
        {
            var tr = new TableRow(this);
            AddElement(tr);
            return this;
        }
        public HTMLBodyElement AddTableRow(out HTMLBodyElement saveIn)
        {
            var tr = new TableRow(this);
            saveIn = tr;
            AddElement(tr);
            return this;
        }

        public HTMLBodyElement AddTableHead()
        {
            var th = new TableHead(this);
            AddElement(th);
            return this;
        }
        public HTMLBodyElement AddTableHead(string text)
        {
            var th = new TableHead(text, this);
            AddElement(th);
            return this;
        }
        public HTMLBodyElement AddTableHead(out HTMLBodyElement saveIn)
        {
            var th = new TableHead(this);
            saveIn = th;
            AddElement(th);
            return this;
        }
        public HTMLBodyElement AddTableHead(out HTMLBodyElement saveIn, string text)
        {
            var th = new TableHead(text, this);
            saveIn = th;
            AddElement(th);
            return this;
        }

        public HTMLBodyElement AddTableData()
        {
            var td = new TableData(this);
            AddElement(td);
            return this;
        }
        public HTMLBodyElement AddTableData(string text)
        {
            var td = new TableData(text, this);
            AddElement(td);
            return this;
        }
        public HTMLBodyElement AddTableData(out HTMLBodyElement saveIn)
        {
            var td = new TableData(this);
            saveIn = td;
            AddElement(td);
            return this;
        }
        public HTMLBodyElement AddTableData(out HTMLBodyElement saveIn, string text)
        {
            var td = new TableData(text, this);
            saveIn = td;
            AddElement(td);
            return this;
        }

        public HTMLBodyElement AddForm(string id)
        {
            var form = new Form(id, this);
            AddElement(form);
            return this;
        }
        public HTMLBodyElement AddForm(out HTMLBodyElement saveIn, string id)
        {
            var form = new Form(id, this);
            AddElement(form);
            saveIn = form;
            return this;
        }

        public HTMLBodyElement AddUnorderedList()
        {
            var list = new UnorderedList(this);
            AddElement(list);
            return this;
        }
        public HTMLBodyElement AddUnorderedList(out HTMLBodyElement saveIn)
        {
            var list = new UnorderedList(this);
            AddElement(list);
            saveIn = list;
            return this;
        }

        public HTMLBodyElement AddOrderedList()
        {
            var list = new OrderedList(this);
            AddElement(list);
            return this;
        }
        public HTMLBodyElement AddOrderedList(out HTMLBodyElement saveIn)
        {
            var list = new OrderedList(this);
            AddElement(list);
            saveIn = list;
            return this;
        }

        public HTMLBodyElement AddListItem()
        {
            var li = new ListItem(this);
            AddElement(li);
            return this;
        }
        public HTMLBodyElement AddListItem(string text)
        {
            var li = new ListItem(text, this);
            AddElement(li);
            return this;
        }
        public HTMLBodyElement AddListItem(out HTMLBodyElement saveIn)
        {
            var li = new ListItem(this);
            AddElement(li);
            saveIn = li;
            return this;
        }
        public HTMLBodyElement AddListItem(out HTMLBodyElement saveIn, string text)
        {
            var li = new ListItem(text, this);
            AddElement(li);
            saveIn = li;
            return this;
        }

        public HTMLBodyElement AddDescriptionList()
        {
            var dl = new DescriptionList(this);
            AddElement(dl);
            return this;
        }
        public HTMLBodyElement AddDescriptionList(out HTMLBodyElement saveIn)
        {
            var dl = new DescriptionList(this);
            saveIn = dl;
            AddElement(dl);
            return this;
        }

        public HTMLBodyElement AddTerm()
        {
            var dt = new Term(this);
            AddElement(dt);
            return this;
        }
        public HTMLBodyElement AddTerm(out HTMLBodyElement saveIn)
        {
            var dt = new Term(this);
            saveIn = dt;
            AddElement(dt);
            return this;
        }

        public HTMLBodyElement AddTermDescription()
        {
            var dd = new TermDescription(this);
            AddElement(dd);
            return this;
        }
        public HTMLBodyElement AddTermDescription(out HTMLBodyElement saveIn)
        {
            var dd = new TermDescription(this);
            saveIn = dd;
            AddElement(dd);
            return this;
        }

        public HTMLBodyElement AddSpan()
        {
            var span = new Span(this);
            AddElement(span);
            return this;
        }
        public HTMLBodyElement AddSpan(out HTMLBodyElement saveIn)
        {
            var span = new Span(this);
            saveIn = span;
            AddElement(span);
            return this;
        }

        public HTMLBodyElement AddIdiomatic()
        {
            var i = new Idiomatic(this);
            AddElement(i);
            return this;
        }
        public HTMLBodyElement AddIdiomatic(out HTMLBodyElement saveIn)
        {
            var i = new Idiomatic(this);
            saveIn = i;
            AddElement(i);
            return this;
        }

        public HTMLBodyElement PlaceTemplate(string templatePath, params string[] replacements)
        {
            var t = new Template(templatePath, replacements);
            AddElement(t);
            return this;
        }
    }
}