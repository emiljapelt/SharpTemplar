
namespace SharpTemplar;
public abstract partial class HTMLHeadElement : HTMLElement
{
    private HTMLHeadElement _Parent;
    internal override HTMLElement Parent 
    { 
        get { return _Parent; }
        set { _Parent = (HTMLHeadElement) value; }
    }
    private HTMLHeadElement _Newest;
    internal override HTMLElement Newest 
    { 
        get { return _Newest; }
        set { _Newest = (HTMLHeadElement) value; }
    }


    protected HTMLHeadElement()
        : base(null) { }


    /// <summary>
    /// Adds attributes of any kind to the Element it is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>        
    public HTMLHeadElement WithAttr(params (string key, string value)[] list)
    {
        AddAttributes(list);
        return this;
    }

    /// <summary>
    /// Adds text into the Element under construction.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLHeadElement InjectHTMLString(string content)
    {
        Newest.Contains.Add(new HTMLString(content));
        return this;
    }
}