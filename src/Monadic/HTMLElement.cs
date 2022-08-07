
namespace SharpTemplar.Monadic;

public abstract class HTMLElement
{
    public void Print()
    {
        Print(0);
    }
    internal abstract void Print(int level);
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
        for(int i = 0; i < level; i++) System.Console.Write("   ");
        System.Console.WriteLine(text);
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
        for(int i = 0; i < level; i++) System.Console.Write("   ");
        System.Console.Write($"<{tagName}");
        if (attributes.Count > 0) {
            foreach((var attr, var val) in attributes) System.Console.Write($" {attr}=\"{val}\"");
        }
        if (children.Count > 0) {
            System.Console.WriteLine(">");
            foreach(var child in children) child.Print(level+1);
            for(int i = 0; i < level; i++) System.Console.Write("   ");
            System.Console.WriteLine($"</{tagName}>");
        }
        else {
            System.Console.WriteLine("/>");
        }
    }
}
