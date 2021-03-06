
namespace SharpTemplar;

public class Paragraph : HTMLBodyElement
{
    internal override string TagType => "p";
    internal Paragraph(HTMLBodyElement parent)
        : base (parent) { }

    internal Paragraph(string text, HTMLBodyElement parent)
        : base (parent) 
    {
        Contains.Add(new HTMLString(text));
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    /// <summary>
    /// Adds Paragraph into the Element it is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLBodyElement AddParagraph()
    {
        var p = new Paragraph(this);
        AddElement(p);
        return this;
    }
    public HTMLBodyElement AddParagraph(out HTMLBodyElement saveIn)
    {
        var p = new Paragraph(this);
        saveIn = p;
        AddElement(p);
        return this;
    }
    public HTMLBodyElement AddParagraph(string content)
    {
        var p = new Paragraph(content, this);
        AddElement(p);
        return this;
    }
    public HTMLBodyElement AddParagraph(out HTMLBodyElement saveIn, string content)
    {
        var p = new Paragraph(content, this);
        saveIn = p;
        AddElement(p);
        return this;
    }
}