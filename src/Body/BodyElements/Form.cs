
namespace SharpTemplar;

public class Form : HTMLBodyElement
{
    private string id;
    internal override string TagType => "form";
    internal Form(string _id, HTMLBodyElement parent)
        : base(parent) 
    {
        id = _id;
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    public HTMLBodyElement AddForm(string id)
    {
        var form = new Form(id, this);
        AddElement(form);
        return this;
    }
    public HTMLBodyElement AddForm(out HTMLBodyElement saveIn, string id)
    {
        var form = new Form(id, this);
        AddElement(form);
        saveIn = form;
        return this;
    }
}