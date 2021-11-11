
namespace SharpTemplar;

public class Strong : HTMLBodyElement
{
    internal override string TagType => "strong";
    internal Strong(HTMLBodyElement parent)
        : base (parent) { }

    internal Strong(string text, HTMLBodyElement parent)
        : base (parent) 
    {
        Contains.Add(new HTMLString(text));
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    /// <summary>
    /// Adds Strong into the Element it is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLBodyElement AddStrong()
    {
        var strong = new Strong(this);
        AddElement(strong);
        return this;
    }
    public HTMLBodyElement AddStrong(out HTMLBodyElement saveIn)
    {
        var strong = new Strong(this);
        saveIn = strong;
        AddElement(strong);
        return this;
    }
    public HTMLBodyElement AddStrong(string text)
    {
        var strong = new Strong(text, this);
        AddElement(strong);
        return this;
    }
    public HTMLBodyElement AddStrong(out HTMLBodyElement saveIn, string text)
    {
        var strong = new Strong(text, this);
        saveIn = strong;
        AddElement(strong);
        return this;
    }
}