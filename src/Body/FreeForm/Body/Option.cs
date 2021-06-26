using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm
{
    public class Option : HTMLBodyElement
    {
        internal override string TagType => "option";
        internal Option(string value, HTMLElement parent)
            : base(parent)
        {
            Attributes.Add("value", value);
        }

        internal Option(string value, string text, HTMLElement parent)
            : base(parent)
        {
            Attributes.Add("value", value);
            Contains.Add(new HTMLString(text));
        }
    }

    public abstract partial class HTMLBodyElement : HTMLElement
    {
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
    }
}