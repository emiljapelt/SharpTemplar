using System.Text;
using Elements.Shared;

namespace Elements.HeadElements
{
    public class Title : HTMLHeadElement
    {
        internal Title(string content)
        {
            tagType = "title";
            Contains.Add(new HTMLHeadString(content));
        }
    }
}