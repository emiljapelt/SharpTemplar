using System.Text;

namespace Elements.BodyElements
{
    public class Form : HTMLBodyElement
    {
        internal Form(HTMLBodyElement parent) 
        {
            tagType = "form";
            Parent = parent;
        }

        public override Form WithAttribute(string key, string value)
        {
            base.WithAttribute(key, value);
            return this;
        }

        public override Form WithAttributes(params (string key, string value)[] list)
        {
            base.WithAttributes(list);
            return this;
        }

        public HTMLBodyElement ExitForm()
        {
            return ToParent();
        }

        public Form AddLabel(string content)
        {
            Contains.Add(new Label(content, this));
            return this;
        }

        public Form AddInput(string type)
        {
            Contains.Add(new Input(type, this));
            return this;
        }

        public Form AddButton(string type, string text)
        {
            Contains.Add(new Button(type, text, this));
            return this;
        }

        public override Form AddBreak()
        {
            base.AddBreak();
            return this;
        }
    }
}