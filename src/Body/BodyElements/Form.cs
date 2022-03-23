
namespace SharpTemplar;

public class Form : HTMLBodyElement
{
    internal override string TagType => "form";
    internal Form(HTMLBodyElement parent)
        : base(parent) {}
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement AddForm()
    {
        var form = new Form(this);
        AddElement(form);
        return this;
    }
    public HTMLBodyElement AddForm(out HTMLBodyElement saveIn)
    {
        var form = new Form(this);
        AddElement(form);
        saveIn = form;
        return this;
    }
}