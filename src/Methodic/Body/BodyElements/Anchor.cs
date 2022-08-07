
namespace SharpTemplar.Methodic;

public class Anchor : HTMLBodyElement
{
    internal override string TagType => "a";
    internal Anchor(string href, HTMLBodyElement parent)
        : base(parent)
    {
        Attributes.Add("href", href);
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    /// <summary>
    /// Adds Anchor into the Element it is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLBodyElement Anchor(string href)
    {           
        var a = new Anchor(href, this);
        AddElement(a);
        return this;
    }
    public HTMLBodyElement Anchor(out HTMLBodyElement saveIn, string href)
    {           
        var a = new Anchor(href, this);
        saveIn = a;
        AddElement(a);
        return this;
    }
}