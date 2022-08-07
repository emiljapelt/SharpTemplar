
namespace SharpTemplar.Methodic;

public class Span : HTMLBodyElement
{
    internal override string TagType => "span";
    internal Span(HTMLBodyElement parent)
            : base(parent) { }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement Span()
    {
        var span = new Span(this);
        AddElement(span);
        return this;
    }
    public HTMLBodyElement Span(out HTMLBodyElement saveIn)
    {
        var span = new Span(this);
        saveIn = span;
        AddElement(span);
        return this;
    }
}