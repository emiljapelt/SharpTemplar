using System.Text;

namespace SharpTemplar;

public class TableHead : HTMLBodyElement
{
    internal override string TagType => "th";

    internal TableHead(HTMLBodyElement parent)
        : base(parent) { }

    internal TableHead(string text, HTMLBodyElement parent)
        : base(parent) 
    {
        Contains.Add(new HTMLString(text));
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement AddTableHead()
    {
        var th = new TableHead(this);
        AddElement(th);
        return this;
    }
    public HTMLBodyElement AddTableHead(string text)
    {
        var th = new TableHead(text, this);
        AddElement(th);
        return this;
    }
    public HTMLBodyElement AddTableHead(out HTMLBodyElement saveIn)
    {
        var th = new TableHead(this);
        saveIn = th;
        AddElement(th);
        return this;
    }
    public HTMLBodyElement AddTableHead(out HTMLBodyElement saveIn, string text)
    {
        var th = new TableHead(text, this);
        saveIn = th;
        AddElement(th);
        return this;
    }
}