using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.BodyElements
{
    public class Paragraph : HTMLBodyElement
    {
        internal override string TagType => "p";
        internal Paragraph(HTMLBodyElement parent)
            : base(parent) {}

        internal Paragraph(string content, HTMLBodyElement parent)
            : base(parent)
        {
            Contains.Add(new HTMLString(content));
        }
    }
}