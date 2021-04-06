using System.Text;
using Elements.BodyElements;
using Elements.HeadElements;

namespace Elements
{
    public class Document
    {
        public Head Head { get; }
        public Body Body { get; }

        public Document()
        {
            Head = new Head("integrationTest");
            Body = new Body();
        }

        public string GeneratePage()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html>");
            Head.ConstructElement(sb);
            Body.ConstructElement(sb);
            sb.Append("</html>");
            return sb.ToString();
        }
    }
}