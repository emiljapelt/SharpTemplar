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

        public Form AddLabel(string content)
        {
            Contains.Add(new Label(content, this));
            return this;
        }

        public Form AddInput()
        {
            Contains.Add(new Input(this));
            return this;
        }
    }
}