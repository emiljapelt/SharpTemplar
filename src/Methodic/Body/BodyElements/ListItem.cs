
namespace SharpTemplar.Methodic;

public class ListItem : HTMLBodyElement
{
    internal override string TagType => "li";
    internal ListItem(HTMLBodyElement parent)
        : base(parent) { }

    internal ListItem(string text, HTMLBodyElement parent)
        : base(parent) 
    {
        Contains.Add(new HTMLString(text));
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement ListItem()
    {
        var li = new ListItem(this);
        AddElement(li);
        return this;
    }
    public HTMLBodyElement ListItem(string text)
    {
        var li = new ListItem(text, this);
        AddElement(li);
        return this;
    }
    public HTMLBodyElement ListItem(out HTMLBodyElement saveIn)
    {
        var li = new ListItem(this);
        AddElement(li);
        saveIn = li;
        return this;
    }
    public HTMLBodyElement ListItem(out HTMLBodyElement saveIn, string text)
    {
        var li = new ListItem(text, this);
        AddElement(li);
        saveIn = li;
        return this;
    }
};