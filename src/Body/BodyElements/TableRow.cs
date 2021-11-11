
namespace SharpTemplar;

public class TableRow : HTMLBodyElement
{
    internal override string TagType => "tr";
    
    internal TableRow(HTMLElement parent)
        : base(parent) { }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement AddTableRow()
    {
        var tr = new TableRow(this);
        AddElement(tr);
        return this;
    }
    public HTMLBodyElement AddTableRow(out HTMLBodyElement saveIn)
    {
        var tr = new TableRow(this);
        saveIn = tr;
        AddElement(tr);
        return this;
    }
}