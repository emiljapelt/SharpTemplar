using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm.BodyElements
{
    public class Strong : HTMLBodyElement
    {
        internal override string TagType => "strong";
        internal Strong(HTMLBodyElement parent)
            : base (parent) { }

        internal Strong(string text, HTMLBodyElement parent)
            : base (parent) 
        {
            Contains.Add(new HTMLString(text));
        }
    }
}