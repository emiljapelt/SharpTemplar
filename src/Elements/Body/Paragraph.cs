using System.Text;
using Elements.Shared;

namespace Elements.BodyElements
{
    public class Paragraph : HTMLBodyElement
    {

        internal Paragraph(string content)
        {
            tagType = "p";
            Contains.Add(new HTMLBodyString(content));
        }
    }
}