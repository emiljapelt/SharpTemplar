
namespace SharpTemplar;

public class Label : HTMLBodyElement
{
    internal override string TagType => "label";
    internal Label(string _refTo, string text, HTMLElement parent)
        : base(parent)
    {
        AddHTMLString(text);
        // Contains.Add(new HTMLString(text));
        Attributes.Add("for", _refTo);
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    /// <summary>
    /// Adds Lable into the Element it is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLBodyElement AddLabel(string refTo, string text)
    {
        var label = new Label(refTo, text, this);
        AddElement(label);
        return this;
    }
    public HTMLBodyElement AddLabel(string refTo, string text, string form)
    {
        var label = new Label(refTo, text, this);
        label.WithAttribute("form", form);
        AddElement(label);
        return this;
    }
}