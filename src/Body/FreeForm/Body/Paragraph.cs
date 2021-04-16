using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm.BodyElements
{
    public class Paragraph : HTMLBodyElement
    {
        internal override string TagType => "p";
        internal Paragraph(HTMLBodyElement parent)
            : base (parent) { }

        internal Paragraph(string text, HTMLBodyElement parent)
            : base (parent) 
        {
            Contains.Add(new HTMLString(text));
        }
    }
}