
namespace SharpTemplar.Methodic;

public class Idiomatic : HTMLBodyElement
{
    internal override string TagType => "i";
    internal Idiomatic(HTMLBodyElement parent)
            : base(parent) { }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement Idiomatic()
    {
        var i = new Idiomatic(this);
        AddElement(i);
        return this;
    }
    public HTMLBodyElement Idiomatic(out HTMLBodyElement saveIn)
    {
        var i = new Idiomatic(this);
        saveIn = i;
        AddElement(i);
        return this;
    }
}