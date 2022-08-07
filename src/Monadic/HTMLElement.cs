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
}

public class HTMLtag : HTMLElement
{
    public HTMLtag parent;
    public List<HTMLElement> children;
    public readonly string tagName;
    public List<(string name, string attr)> attributes;

    public HTMLtag(string t, HTMLtag p)
    {
        parent = p;
        tagName = t;
        children = new List<HTMLElement>();
        attributes = new List<(string name, string attr)>();
    }

    public HTMLtag(string t)
    {
        tagName = t;
        children = new List<HTMLElement>();
        attributes = new List<(string name, string attr)>();
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
}
