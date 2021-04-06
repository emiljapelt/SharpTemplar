using System.Text;
using Elements.BodyElements;
using Elements.HeadElements;

namespace Elements
{
    public class TemplarDocument
    {
        public Head Head { get; }
        public Body Body { get; }

        public TemplarDocument()
        {
            Head = new Head("integrationTest");
            Body = new Body();
        }

        public string GeneratePage()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<!DOCTYPE html>");
            sb.Append("<html>");
            sb.Append("<meta charset=\"UTF-8\">");
            Head.ConstructElement(sb);
            Body.ConstructElement(sb);
            sb.Append("</html>");
            return sb.ToString();
        }
    }
}