
namespace SharpTemplar;

public class UnorderedList : HTMLBodyElement
{
    internal override string TagType => "ul";
    internal UnorderedList(HTMLBodyElement parent)
        : base(parent) { }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement AddUnorderedList()
    {
        var list = new UnorderedList(this);
        AddElement(list);
        return this;
    }
    public HTMLBodyElement AddUnorderedList(out HTMLBodyElement saveIn)
    {
        var list = new UnorderedList(this);
        AddElement(list);
        saveIn = list;
        return this;
    }
}