using System.Text;

namespace SharpTemplar;

public abstract class XMLElement
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

    internal abstract XMLElement Clone();
}

public class XMLtext : XMLElement
{
    private string text;

    public XMLtext(string t)
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

    internal override XMLElement Clone()
    {
        return new XMLtext(text);
    }
}

public class XMLtag : XMLElement
{
    internal XMLtag parent;
    internal List<XMLElement> children;
    internal readonly string tagName;
    internal readonly Dictionary<string, string> attributes;
    private XMLtag clone;

    public XMLtag(string t, XMLtag p)
    {
        parent = p;
        tagName = t;
        children = new List<XMLElement>();
        attributes = new Dictionary<string, string>();
    }

    public XMLtag(string t)
    {
        tagName = t;
        children = new List<XMLElement>();
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

    public void AddChild(XMLElement element) 
    {
        if (element is XMLtag t) t.parent = this;
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

    internal override XMLElement Clone()
    {
        return CloneFunc(this);
    }

    public XMLtag RefingClone()
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

    private Func<XMLtag, XMLElement> CloneFunc = DefaultCloning;

    private static readonly Func<XMLtag, XMLElement> DefaultCloning = (t) => {
        var clone = new XMLtag(t.tagName);
        foreach(var attr in t.attributes) clone.AddAttribute(attr.Key, attr.Value);
        foreach (var child in t.children) clone.AddChild(child.Clone());
        return clone;
    };

    private static readonly Func<XMLtag, XMLElement> RefingCloning = (t) => {
        var clone = new XMLtag(t.tagName);
        foreach(var attr in t.attributes) clone.AddAttribute(attr.Key, attr.Value);
        foreach (var child in t.children) clone.AddChild(child.Clone());
        t.clone = clone;
        return clone;
    };
}
