
namespace SharpTemplar.Methodic;

public class DescriptionList : HTMLBodyElement
{
    internal override string TagType => "dl";
    internal DescriptionList(HTMLBodyElement parent)
        : base(parent) { }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement DescriptionList()
    {
        var dl = new DescriptionList(this);
        AddElement(dl);
        return this;
    }
    public HTMLBodyElement DescriptionList(out HTMLBodyElement saveIn)
    {
        var dl = new DescriptionList(this);
        saveIn = dl;
        AddElement(dl);
        return this;
    }
}