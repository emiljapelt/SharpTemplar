
namespace SharpTemplar.Methodic;

public class Button : HTMLBodyElement
{
    internal override string TagType => "button";
    internal Button(string type, string text, HTMLBodyElement parent)
        : base(parent)
    {
        Attributes.Add("type", type);
        Contains.Add(new HTMLString(text));
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    /// <summary>
    /// Adds Button into the Element it is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLBodyElement Button(string type, string text)
    {
        var button = new Button(type, text, this);
        AddElement(button);
        return this;
    }
}