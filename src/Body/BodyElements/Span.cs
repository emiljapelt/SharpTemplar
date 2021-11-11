
namespace SharpTemplar;

public class Span : HTMLBodyElement
{
    internal override string TagType => "span";
    internal Span(HTMLBodyElement parent)
            : base(parent) { }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement AddSpan()
    {
        var span = new Span(this);
        AddElement(span);
        return this;
    }
    public HTMLBodyElement AddSpan(out HTMLBodyElement saveIn)
    {
        var span = new Span(this);
        saveIn = span;
        AddElement(span);
        return this;
    }
}