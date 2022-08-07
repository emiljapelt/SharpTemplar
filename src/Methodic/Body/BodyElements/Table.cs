
namespace SharpTemplar.Methodic;

public class Table : HTMLBodyElement
{
    internal override string TagType => "table";
    
    internal Table(HTMLBodyElement parent)
        : base(parent) { }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement Table()
    {
        var table = new Table(this);
        AddElement(table);
        return this;
    }
    public HTMLBodyElement Table(out HTMLBodyElement saveIn)
    {
        var table = new Table(this);
        saveIn = table;
        AddElement(table);
        return this;
    }
}