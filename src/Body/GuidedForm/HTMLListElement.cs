using SharpTemplar.GuidedForm.ListElements;

namespace SharpTemplar.GuidedForm
{
    public abstract class HTMLListElement : HTMLElement
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


        protected HTMLListElement(HTMLElement parent)
            : base(parent) { }


        public HTMLBodyElement ExitList()
        {
            ResetThisElement();
            _Parent.ResetThisElement();
            return (HTMLBodyElement) _Parent;
        }

        public HTMLListElement WithAttribute(string key, string value)
        {
            AddAttribute(key, value);
            return this;
        }

        public HTMLListElement AddItem(out HTMLBodyElement saveIn)
        {
            var li = new ListItem(this);
            AddElement(li);
            saveIn = li;
            return this;
        }

        public HTMLListElement AddTextItem(string text)
        {
            var li = new ListItem(text, this);
            AddElement(li);
            return this;
        }
    }
}