
namespace SharpTemplar.Methodic;

public class Select : HTMLBodyElement
{
    internal override string TagType => "select";
    internal Select(string name, HTMLElement parent)
        : base(parent)
    {
        Attributes.Add("name", name);
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement Select(string name)
    {
        var select = new Select(name, this);
        AddElement(select);
        return this;
    }

    public HTMLBodyElement Select(out HTMLBodyElement saveIn, string name)
    {
        var select = new Select(name, this);
        saveIn = select;
        AddElement(select);
        return this;
    }
}