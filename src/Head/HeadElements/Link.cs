
namespace SharpTemplar;

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

public abstract partial class HTMLHeadElement : HTMLElement
{
    /// <summary>
    /// Adds Link into the Element it is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLHeadElement AddLink(string rel, string href)
    {
        var link = new Link(rel, href);
        AddElement(link);
        return this;
    }
};