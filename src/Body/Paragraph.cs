using SharpTemplar.Shared;

namespace SharpTemplar.BodyElements
{
    public class Paragraph : HTMLBodyElement
    {
        internal Paragraph(HTMLBodyElement parent)
            : base("p", parent) {}

        internal Paragraph(string content, HTMLBodyElement parent)
            : base("p", parent)
        {
            Contains.Add(new HTMLString(content));
        }
    }
}