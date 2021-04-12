using Elements.TableElements;

namespace Elements
{
    public abstract class HTMLTableElement : HTMLElement
    {
        private HTMLElement _Parent;
        internal override HTMLElement Parent 
        { 
            get { return _Parent; }
            set { _Parent = value; }
        }
        private HTMLTableElement _Newest;
        internal override HTMLElement Newest 
        { 
            get { return _Newest; }
            set { _Newest = (HTMLTableElement) value; }
        }


        protected HTMLTableElement(string tagType, HTMLElement parent)
            : base(tagType, parent) { }


        public HTMLBodyElement ExitTable()
        {
            FinishConstruction();
            _Parent.FinishConstruction();
            return (HTMLBodyElement) _Parent;
        }

        public virtual HTMLTableElement WithAttribute(string key, string value)
        {
            AddAttribute(key, value);
            return this;
        }

        public HTMLTableElement AddTableData(params string[] columns)
        {
            var data = new TableData(this, columns);
            AddElement(data);
            return this;
        }
    }
}