
namespace SharpTemplar.Methodic;

public class Small : HTMLBodyElement
{
    internal override string TagType => "small";
    internal Small(HTMLBodyElement parent)
        : base (parent) { }

    internal Small(string text, HTMLBodyElement parent)
        : base (parent) 
    {
        Contains.Add(new HTMLString(text));
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    /// <summary>
    /// Adds Small into the Element it is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLBodyElement Small()
    {
        var small = new Small(this);
        AddElement(small);
        return this;
    }
    public HTMLBodyElement Small(out HTMLBodyElement saveIn)
    {
        var small = new Small(this);
        saveIn = small;
        AddElement(small);
        return this;
    }
    public HTMLBodyElement Small(string text)
    {
        var small = new Small(text, this);
        AddElement(small);
        return this;
    }
    public HTMLBodyElement Small(out HTMLBodyElement saveIn, string text)
    {
        var small = new Small(text, this);
        saveIn = small;
        AddElement(small);
        return this;
    }
};