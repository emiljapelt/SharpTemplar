
namespace SharpTemplar.Methodic;

public class TableRow : HTMLBodyElement
{
    internal override string TagType => "tr";
    
    internal TableRow(HTMLElement parent)
        : base(parent) { }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement TableRow()
    {
        var tr = new TableRow(this);
        AddElement(tr);
        return this;
    }
    public HTMLBodyElement TableRow(out HTMLBodyElement saveIn)
    {
        var tr = new TableRow(this);
        saveIn = tr;
        AddElement(tr);
        return this;
    }
}