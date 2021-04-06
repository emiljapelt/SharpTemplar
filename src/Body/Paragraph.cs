using System.Text;
using Elements.Shared;

namespace Elements.BodyElements
{
    public class Paragraph : HTMLBodyElement
    {

        internal Paragraph(string content, HTMLBodyElement parent)
        {
            tagType = "p";
            Parent = parent;
            Contains.Add(new HTMLBodyString(content));
        }
    }
}