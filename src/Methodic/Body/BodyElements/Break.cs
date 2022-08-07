using System.Text;

namespace SharpTemplar.Methodic;

public class Break : HTMLBodyElement
{
    internal override string TagType => "br";
    internal Break()
        : base (null) {}

    internal override void ConstructElement(StringBuilder sb)
    {
        sb.Append($"<{TagType}>");
    }
}

public abstract partial class HTMLBodyElement : HTMLElement
{
    /// <summary>
    /// Adds break into the Element it is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public virtual HTMLBodyElement Break()
    {
        ResetThisElement();
        Contains.Add(new Break());
        return this;
    }
}