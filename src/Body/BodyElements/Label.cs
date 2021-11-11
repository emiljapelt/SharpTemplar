
namespace SharpTemplar;

public class Label : HTMLBodyElement
{
    internal override string TagType => "label";
    internal Label(string _refTo, string content, HTMLElement parent)
        : base(parent)
    {
        Contains.Add(new HTMLString(content));
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
    public HTMLBodyElement AddLabel(string form, string refTo, string content)
    {
        var label = new Label(refTo, content, this);
        label.WithAttribute("form", form);
        AddElement(label);
        return this;
    }
}