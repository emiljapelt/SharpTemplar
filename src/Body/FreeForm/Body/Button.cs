using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm.BodyElements
{
    public class Button : HTMLBodyElement
    {
        internal override string TagType => "button";
        internal Button(string type, string text, HTMLBodyElement parent)
            : base(parent)
        {
            Attributes.Add("type", type);
            Contains.Add(new HTMLString(text));
        }
    }
}