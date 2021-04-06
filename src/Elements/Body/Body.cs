using System.Text;

namespace Elements.BodyElements
{
    public class Body : HTMLBodyElement
    {
        internal Body() {}

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append("<body>");
            foreach(HTMLElement e in Container)
            {
                e.ConstructElement(sb);
            }
            sb.Append("</body>");
        }
    }
}