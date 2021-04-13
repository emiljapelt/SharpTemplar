using SharpTemplar.ListElements;
using SharpTemplar.Shared;

namespace SharpTemplar
{
    public abstract class HTMLListItemElement : HTMLElement
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


        protected HTMLListItemElement(string tagType, HTMLListElement parent)
            : base(tagType, parent) { }


        public HTMLBodyElement Finish()
        {
            FinishConstruction();
            _Parent.FinishConstruction();
            return (HTMLBodyElement) _Parent;
        }

        public HTMLListItemElement WithAttribute(string key, string value)
        {
            AddAttribute(key, value);
            return this;
        }

        public HTMLListItemElement AddStrong(string content)
        {
            var strong = new Strong(content, this);
            AddElement(strong);
            return this;
        }

        public HTMLListItemElement AddSmall(string content)
        {
            var small = new Small(content, this);
            AddElement(small);
            return this;
        }

        public HTMLListItemElement InsertHTMLString(string content)
        {
            FinishConstruction();
            Contains.Add(new HTMLString(content));
            return this;
        }
    }
}