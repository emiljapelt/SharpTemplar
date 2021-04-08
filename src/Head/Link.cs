using System.Text;

namespace Elements.HeadElements
{
    public class Link : HTMLHeadElement
    {
        internal Link(string rel, string href)
        {
            tagType = "link";
            Attributes.Add("rel", rel);
            Attributes.Add("href", href);
        }
    }
}