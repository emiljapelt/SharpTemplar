using System.Collections.Generic;

namespace Elements
{
    public abstract class HTMLTableDataElement : HTMLElement
    {
        private HTMLElement _Parent;
        internal override HTMLElement Parent 
        { 
            get { return _Parent; }
            set { _Parent = value; }
        }
        private HTMLTableDataElement _Newest;
        internal override HTMLElement Newest 
        { 
            get { return _Newest; }
            set { _Newest = (HTMLTableDataElement) value; }
        }


        protected HTMLTableDataElement(string tagType, HTMLElement parent)
            : base(tagType, parent) { }

    }
}