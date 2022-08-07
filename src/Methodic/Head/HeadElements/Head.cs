
namespace SharpTemplar.Methodic;

public class Head : HTMLHeadElement
{
    internal override string TagType => "head";
    internal Head(string title)
        : base()
    {
        Contains.Add(new Title(title));
    }


    /// <summary>
    /// Adds meta tag with charset=UTF-8, and meta tag with name=viewport and content=width=device-width, initial-scale=1.0.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLHeadElement AddDefaults()
    {
        Meta().WithAttr(("charset","UTF-8"));
        Meta().WithAttr(("name","viewport"),("content","width=device-width, initial-scale=1.0"));

        ResetThisElement();
        return this;
    }
}