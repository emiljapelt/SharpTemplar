
namespace SharpTemplar.HeadElements
{
    public class Link : HTMLHeadElement
    {
        internal override string TagType => "link";
        internal Link(string rel, string href)
            : base()
        {
            Attributes.Add("rel", rel);
            Attributes.Add("href", href);
        }
    }
}