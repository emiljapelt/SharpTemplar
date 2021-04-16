using SharpTemplar.GuidedForm.FormElements;
using SharpTemplar.GuidedForm.Shared;

namespace SharpTemplar.GuidedForm
{
    public abstract class HTMLFormElement : HTMLElement
    {
        private HTMLElement _Parent;
        internal override HTMLElement Parent 
        { 
            get { return _Parent; }
            set { _Parent = (HTMLElement) value; }
        }
        private HTMLElement _Newest;
        internal override HTMLElement Newest 
        { 
            get { return _Newest; }
            set { _Newest = value; }
        }


        protected HTMLFormElement(HTMLElement parent)
            : base(parent) { }


        public HTMLBodyElement ExitForm()
        {
            FinishConstruction();
            _Parent.FinishConstruction();
            return (HTMLBodyElement) _Parent;
        }

        public HTMLFormElement WithAttribute(string key, string value)
        {
            AddAttribute(key, value);
            return this;
        }

        public HTMLFormElement AddBreak()
        {
            FinishConstruction();
            Contains.Add(new Break());
            return this;
        }

        public HTMLFormElement AddLabel(string refTo, string text)
        {
            var label = new Label(refTo, text, this);
            AddElement(label);
            return this;
        }

        public HTMLFormElement AddInput(string id, string type)
        {
            var input = new Input(id, type, this);
            AddElement(input);
            return this;
        }

        public HTMLFormElement AddButton(string type, string text)
        {
            var button = new Button(type, text, this);
            AddElement(button);
            return this;
        }

    }
}