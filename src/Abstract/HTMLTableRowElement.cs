using System.Collections.Generic;
using SharpTemplar.TableElements;

namespace SharpTemplar
{
    public abstract class HTMLTableRowElement : HTMLElement
    {
        protected List<string> data;

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


        protected HTMLTableRowElement(string tagType, HTMLElement parent)
            : base(tagType, parent) 
            {
                data = new List<string>();
            }

        
        public HTMLTableElement ExitRow()
        {
            FinishConstruction();
            _Parent.FinishConstruction();
            return (HTMLTableElement) _Parent;
        }

        public HTMLTableRowElement WithAttribute(string key, string value)
        {
            AddAttribute(key, value);
            return this;
        }

        public HTMLTableRowElement AddHead(string _data)
        {
            var head = new TableHead(this, _data);
            AddElement(head);
            return this;
        }

        public HTMLTableRowElement AddData(string _data)
        {
            var data = new TableData(this, _data);
            AddElement(data);
            return this;
        }
    }
}