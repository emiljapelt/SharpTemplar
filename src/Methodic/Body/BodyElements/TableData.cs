
namespace SharpTemplar.Methodic;

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
    public HTMLBodyElement TableData()
    {
        var td = new TableData(this);
        AddElement(td);
        return this;
    }
    public HTMLBodyElement TableData(string text)
    {
        var td = new TableData(text, this);
        AddElement(td);
        return this;
    }
    public HTMLBodyElement TableData(out HTMLBodyElement saveIn)
    {
        var td = new TableData(this);
        saveIn = td;
        AddElement(td);
        return this;
    }
    public HTMLBodyElement TableData(out HTMLBodyElement saveIn, string text)
    {
        var td = new TableData(text, this);
        saveIn = td;
        AddElement(td);
        return this;
    }
}