using System.Text;

namespace Elements.HeadElements
{
    public class Title : HTMLHeadElement
    {
        private string Content;

        internal Title(string content)
        {
            Content = content;
        }

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<title>{Content}</title>");
        }
    }
}