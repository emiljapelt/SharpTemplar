using System.Text;

namespace Elements.BodyElements
{
    public class Paragraph : HTMLBodyElement
    {
        public string Content { get; set; }
        internal Paragraph(string content)
        {
            ElementTag = "p";
            Content = content;
        }

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append("<p>");
            sb.Append(Content);
            sb.Append("</p>");
        }
    }
}