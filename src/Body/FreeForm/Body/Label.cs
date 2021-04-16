using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm.FormElements
{
    public class Label : HTMLBodyElement
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