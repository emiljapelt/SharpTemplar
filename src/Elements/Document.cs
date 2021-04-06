using System.Text;

namespace Elements
{
    public class Document
    {
        public Head Head { get; }
        public Body Body { get; }

        public Document()
        {
            Head = new Head();
            Body = new Body();
        }

        public string GeneratePage()
        {
            StringBuilder sb = new StringBuilder();
            foreach(HTMLElement e in Body.Container)
            {
                sb.Append(e.ElementTag);
            }
            return sb.ToString();
        }
    }
}