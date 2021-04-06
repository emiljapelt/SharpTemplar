using System.Text;

namespace Elements.HeadElements
{
    public class Head : HTMLHeadElement
    {
        internal Head(string title) 
        {
            tagType = "head";
            Contains.Add(new Title(title));
        }
    }
}