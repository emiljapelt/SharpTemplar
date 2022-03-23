
namespace SharpTemplar;

public class Input : HTMLBodyElement
{
    internal override string TagType => "input";
    internal Input(string type, string name, HTMLElement parent)
        : base(parent)
    {
        AddAttribute("type", type);
        AddAttribute("name", name);
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    /// <summary>
    /// Adds Input into the Element it is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLBodyElement AddInput(string type, string name)
    {
        var input = new Input(type, name, this);
        AddElement(input);
        return this;
    }

    public HTMLBodyElement AddInput(string type, string name, string form)
    {
        var input = new Input(type, name, this);
        input.AddAttribute("form", form);
        AddElement(input);
        return this;
    }
}