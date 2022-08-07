
namespace SharpTemplar.Methodic;

public class Term : HTMLBodyElement
{
    internal override string TagType => "dt";
    internal Term(HTMLBodyElement parent)
        : base(parent) { }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement Term()
    {
        var dt = new Term(this);
        AddElement(dt);
        return this;
    }
    public HTMLBodyElement Term(out HTMLBodyElement saveIn)
    {
        var dt = new Term(this);
        saveIn = dt;
        AddElement(dt);
        return this;
    }
}