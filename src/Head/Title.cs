using System.Text;
using Elements.Shared;

namespace Elements.HeadElements
{
    public class Title : HTMLHeadElement
    {
        internal Title(string content)
            : base("title")
        {
            Contains.Add(new HTMLString(content));
        }
    }
}