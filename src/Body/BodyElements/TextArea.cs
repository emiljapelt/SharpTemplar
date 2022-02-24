
namespace SharpTemplar;

public class TextArea : HTMLBodyElement
{
    internal override string TagType => "textarea";

    internal TextArea(HTMLBodyElement parent)
        : base(parent) {}

    internal TextArea(uint? rows, uint? cols, HTMLBodyElement parent)
        : base(parent) 
    {
        if (rows is not null) Attributes.Add("rows", $"{rows}");
        if (cols is not null) Attributes.Add("cols", $"{cols}");
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement AddTextArea()
    {
        var ta = new TextArea(this);
        AddElement(ta);
        return this;
    }
    public HTMLBodyElement AddTextArea(out HTMLBodyElement saveIn)
    {
        var ta = new TextArea(this);
        saveIn = ta;
        AddElement(ta);
        return this;
    }
    public HTMLBodyElement AddTextArea(uint? rows, uint? cols)
    {
        var ta = new TextArea(rows, cols, this);
        AddElement(ta);
        return this;
    }
    public HTMLBodyElement AddTextArea(out HTMLBodyElement saveIn, uint? rows, uint? cols)
    {
        var ta = new TextArea(rows, cols, this);
        saveIn = ta;
        AddElement(ta);
        return this;
    }
}