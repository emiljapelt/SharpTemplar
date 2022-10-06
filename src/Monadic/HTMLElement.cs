using System.Text;

namespace SharpTemplar.Monadic;

public abstract class HTMLElement
{
    public void Print()
    { Print(0); }
    internal abstract void Print(int level);

    public string Build()
    {
        var sb = new StringBuilder();
        Build(0, sb);
        return sb.ToString();
    }
    internal abstract void Build(int level, StringBuilder sb);

    internal abstract HTMLElement Clone();
}

public class HTMLtext : HTMLElement
{
    private string text;

    public HTMLtext(string t)
    {
        text = t;
    }

    internal override void Print(int level)
    {
        var sb = new StringBuilder();
        Build(level, sb);
        Console.WriteLine(sb.ToString());
    }

    internal override void Build(int level, StringBuilder sb)
    {
        for(int i = 0; i < level; i++)sb.Append("   ");
        sb.Append(text+"\n");
    }

    internal override HTMLElement Clone()
    {
        return new HTMLtext(text);
    }
}

public class HTMLtag : HTMLElement
{
    internal HTMLtag parent;
    internal List<HTMLElement> children;
    internal readonly string tagName;
    internal readonly Dictionary<string, string> attributes;
    private HTMLtag clone;

    public HTMLtag(string t, HTMLtag p)
    {
        parent = p;
        tagName = t;
        children = new List<HTMLElement>();
        attributes = new Dictionary<string, string>();
    }

    public HTMLtag(string t)
    {
        tagName = t;
        children = new List<HTMLElement>();
        attributes = new Dictionary<string, string>();
    }

    public void AddAttribute(string key, string value) 
    {
        string oldvalue;
        if(attributes.TryGetValue(key, out oldvalue)) {
            attributes[key] =  $"{oldvalue} {value}";
        }
        else {
            attributes.Add(key, value);
        }
    }

    public void AddChild(HTMLElement element) 
    {
        if (element is HTMLtag t) t.parent = this;
        children.Add(element);
    }

    internal override void Print(int level)
    {
        var sb = new StringBuilder();
        Build(0, sb);
        Console.WriteLine(sb.ToString());
    }

    internal override void Build(int level, StringBuilder sb)
    {
        for(int i = 0; i < level; i++) sb.Append("   ");
        sb.Append($"<{tagName}");
        if (attributes.Count > 0) {
            foreach((var attr, var val) in attributes) sb.Append($" {attr}=\"{val}\"");
        }
        if (children.Count > 0) {
            sb.Append(">\n");
            foreach(var child in children) child.Build(level+1, sb);
            for(int i = 0; i < level; i++) sb.Append("   ");
            sb.Append($"</{tagName}>\n");
        }
        else {
            sb.Append("/>\n");
        }
    }

    internal override HTMLElement Clone()
    {
        return CloneFunc(this);
    }

    public HTMLtag RefingClone()
    {
        CloneFunc = RefingCloning;
        var p = this;
        while(p.parent is not null) p = p.parent;
        p.Clone();
        CloneFunc = DefaultCloning;
        var temp = clone;
        clone = null;
        return temp;
    }

    private Func<HTMLtag, HTMLElement> CloneFunc = DefaultCloning;

    private static readonly Func<HTMLtag, HTMLElement> DefaultCloning = (t) => {
        var clone = new HTMLtag(t.tagName);
        foreach(var attr in t.attributes) clone.AddAttribute(attr.Key, attr.Value);
        foreach (var child in t.children) clone.AddChild(child.Clone());
        return clone;
    };

    private static readonly Func<HTMLtag, HTMLElement> RefingCloning = (t) => {
        var clone = new HTMLtag(t.tagName);
        foreach(var attr in t.attributes) clone.AddAttribute(attr.Key, attr.Value);
        foreach (var child in t.children) clone.AddChild(child.Clone());
        t.clone = clone;
        return clone;
    };
}
