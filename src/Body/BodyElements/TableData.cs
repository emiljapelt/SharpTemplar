
namespace SharpTemplar;

public class TableData : HTMLBodyElement
{
    internal override string TagType => "td";
    
    internal TableData(HTMLBodyElement parent)
        : base(parent) { }

    internal TableData(string text, HTMLBodyElement parent)
        : base(parent) 
    {
        Contains.Add(new HTMLString(text));
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement AddTableData()
    {
        var td = new TableData(this);
        AddElement(td);
        return this;
    }
    public HTMLBodyElement AddTableData(string text)
    {
        var td = new TableData(text, this);
        AddElement(td);
        return this;
    }
    public HTMLBodyElement AddTableData(out HTMLBodyElement saveIn)
    {
        var td = new TableData(this);
        saveIn = td;
        AddElement(td);
        return this;
    }
    public HTMLBodyElement AddTableData(out HTMLBodyElement saveIn, string text)
    {
        var td = new TableData(text, this);
        saveIn = td;
        AddElement(td);
        return this;
    }
}