using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm.BodyElements
{
    public class Small : HTMLBodyElement
    {
        internal override string TagType => "small";
        internal Small(HTMLBodyElement parent)
            : base (parent) { }

        internal Small(string text, HTMLBodyElement parent)
            : base (parent) 
        {
            Contains.Add(new HTMLString(text));
        }
    }
}