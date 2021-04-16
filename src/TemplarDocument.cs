using System.Text;
using SharpTemplar.HeadElements;

namespace SharpTemplar
{
    public abstract class TemplarDocument
    {
        public Head Head { get; }
        internal virtual HTMLElement _Body { get; set; }

        protected TemplarDocument(string title)
        {
            Head = new Head(title);
        }

        public string GeneratePage()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            Head.ConstructElement(sb);
            _Body.ConstructElement(sb);
            sb.Append("</html>");
            return sb.ToString();
        }
    }
}