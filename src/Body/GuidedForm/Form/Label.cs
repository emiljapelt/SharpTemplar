using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.FormElements
{
    public class Label : HTMLFormElement
    {
        internal override string TagType => "label";
        internal Label(string _refTo, string content, HTMLElement parent)
            : base(parent)
        {
            Contains.Add(new HTMLString(content));
            Attributes.Add("for", _refTo);
        }
    }
}