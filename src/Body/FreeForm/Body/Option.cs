using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm.BodyElements
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
}