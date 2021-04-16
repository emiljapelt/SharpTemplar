using SharpTemplar.GuidedForm.TableElements;

namespace SharpTemplar.GuidedForm
{
    public abstract class HTMLTableElement : HTMLElement
    {
        private HTMLElement _Parent;
        internal override HTMLElement Parent 
        { 
            get { return _Parent; }
            set { _Parent = value; }
        }
        private HTMLElement _Newest;
        internal override HTMLElement Newest 
        { 
            get { return _Newest; }
            set { _Newest = (HTMLElement) value; }
        }


        protected HTMLTableElement(HTMLElement parent)
            : base(parent) { }


        public HTMLBodyElement ExitTable()
        {
            FinishConstruction();
            _Parent.FinishConstruction();
            return (HTMLBodyElement) _Parent;
        }

        public HTMLTableElement WithAttribute(string key, string value)
        {
            AddAttribute(key, value);
            return this;
        }

        public HTMLTableRowElement BeginRow()
        {
            var row = new TableRow(this);
            AddElement(row);
            return row;
        }
    }
}