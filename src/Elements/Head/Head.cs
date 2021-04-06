using System.Text;

namespace Elements.HeadElements
{
    public class Head : HTMLElement
    {
        private Title Title;
        internal Head(string title) 
        {
            Title = new Title(title);
        }

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append("<head>");
            Title.ConstructElement(sb);
            sb.Append("</head>");
        }
    }
}