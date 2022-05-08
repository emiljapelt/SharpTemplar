
namespace SharpTemplar;

public abstract partial class HTMLBodyElement : HTMLElement
{

    protected HTMLBodyElement(HTMLElement parent)
        : base(parent) { }


    /// <summary>
    /// Navigates to the Parent Element. For the Body element, the parent is itself.
    /// </summary>
    /// <returns>
    /// Parent of the Element it is called on.
    /// </returns>
    public HTMLBodyElement Exit
    {
        get { 
            ResetThisElement(); 
            return (HTMLBodyElement) Parent; 
        }
    }

    /// <summary>
    /// Navigates to the newest added element. For Element where no Elements have been added, the newest element is itself.
    /// </summary>
    /// <returns>
    /// Most recently added Element.
    /// </returns>
    public HTMLBodyElement Enter
    {
        get {
            var toEnter = Newest;
            ResetThisElement();
            return (HTMLBodyElement) toEnter;
        }
    }

    /// <summary>
    /// Resets this element
    /// </summary>
    /// <returns>
    /// The element it was called on
    /// </returns>
    public void End()
    {
        ResetThisElement();
    }

    // /// <summary>
    // /// Add an attributes of any kind to the Element it is called on.
    // /// </summary>
    // /// <returns>
    // /// The Element it is called on.
    // /// </returns>
    public virtual  HTMLBodyElement WithAttr(params (string key, string value)[] list)
    {
        AddAttributes(list);
        return this;
    }
    
    /// <summary>
    /// Adds a class attribute to the Element it is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLBodyElement WithClass(string value)
    {
        return WithAttr(("class", value));
    }

    public HTMLBodyElement WithClasses(params string[] values)
    {
        foreach (var c in values) WithClass(c);
        return this;
    }

    public HTMLBodyElement WithId(string value)
    {
        WithAttr(("id", value));
        return this;
    }

    /// <summary>
    /// Adds style attribute to the Element it is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLBodyElement WithStyle(string value)
    {
        return WithAttr(("style", value));
    }

    /// <summary>
    /// Adds text into the Element this is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLBodyElement AddHTMLString(string content)
    {
        ResetThisElement();
        Contains.Add(new HTMLString(content));
        return this;
    }

    /// <summary>
    /// Adds text into the most recently added Element, in the Element this is called on.
    /// </summary>
    /// <returns>
    /// The Element it is called on.
    /// </returns>
    public HTMLBodyElement InjectHTMLString(string content)
    {
        Newest.Contains.Add(new HTMLString(content));
        return this;
    }

    public HTMLBodyElement OnEvent(HTMLEvent eventName, string functionName, params object[] functionArguments)
    {
        for (int i = 0; i < functionArguments.Length; i++)
        {
            if (functionArguments[i] is string) functionArguments[i] = $"'{functionArguments[i]}'";
        }

        var args = string.Join(",", functionArguments);
        string function = functionName + "(" + args + ")";
        
        AddAttribute("on"+eventName.ToString().ToLower(),function);
        return this;
    }
}