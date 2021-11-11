
namespace SharpTemplar;

public class Input : HTMLBodyElement
{
    internal override string TagType => "input";
    internal Input(string id, string type, HTMLElement parent)
        : base(parent)
    {
        Attributes.Add("type", type);
        Attributes.Add("id", id);
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
    public HTMLBodyElement AddInput(string id, string type)
    {
        var input = new Input(id, type, this);
        AddElement(input);
        return this;
    }
}