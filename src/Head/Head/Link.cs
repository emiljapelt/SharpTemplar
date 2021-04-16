
namespace SharpTemplar.HeadElements
{
    public class Link : HTMLHeadElement
    {
        internal Link(string rel, string href)
            : base("link")
        {
            Attributes.Add("rel", rel);
            Attributes.Add("href", href);
        }
    }
}