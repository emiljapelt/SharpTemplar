using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.FormElements
{
    public class Button : HTMLFormElement
    {
        internal override string TagType => "button";
        internal Button(string type, string text, HTMLElement parent)
            : base(parent)
        {
            Attributes.Add("type", type);
            Contains.Add(new HTMLString(text));
        }
    }
}