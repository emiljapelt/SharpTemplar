
namespace SharpTemplar.Methodic;

public class OrderedList : HTMLBodyElement
{
    internal override string TagType => "ol";
    internal OrderedList(HTMLBodyElement parent)
        : base(parent) { }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement OrderedList()
    {
        var list = new OrderedList(this);
        AddElement(list);
        return this;
    }
    public HTMLBodyElement OrderedList(out HTMLBodyElement saveIn)
    {
        var list = new OrderedList(this);
        AddElement(list);
        saveIn = list;
        return this;
    }
}