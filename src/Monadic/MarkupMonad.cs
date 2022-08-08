using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic;

public abstract class MMonad
{
    public abstract MMonad _(Functor f);
    public abstract MMonad Print();
    public abstract string Build();
    public abstract MMonad Out(out MMonad to);
}

public class MarkupMonad : MMonad
{
    internal HTMLtag pointer;
    internal HTMLtag newest;
    internal HashSet<string> ids;

    public static MarkupMonad Markup()
    { 
        return new MarkupMonad(new HTMLtag("html"), new HashSet<string>()); 
    }

    public MarkupMonad(HTMLtag p, HashSet<string> i)
    {
        pointer = p;
        ids = i;
    }

    internal void addHTMLtag(string tagName)
    {
        var tag = new HTMLtag(tagName, pointer);
        pointer.children.Add(tag);
        newest = tag;
    }

    internal bool isInside(string tagName)
    {
        var temp = pointer;
        while(true) {
            if (temp.tagName == tagName) return true;
            if (temp.parent is null) return false;
            temp = temp.parent;
        }
    }

    internal MMonad newestOrCurrent(Func<HTMLtag, MMonad> f) {
        if (newest is null) return f(pointer); 
        else return f(newest);
    }

    public override MMonad _(Functor f)
    {
        return f(this);
    }

    public override MMonad Print()
    {
        var temp = pointer;
        while(temp.parent is not null) temp = temp.parent;
        temp.Print();
        return this;
    }

    public override MMonad Out(out MMonad to)
    {
        if (newest is not null) to = new MarkupMonad(newest, ids);
        else to = new MarkupMonad(pointer, ids);
        return this;
    }

    public override string Build()
    {
        var temp = pointer;
        while(temp.parent is not null) temp = temp.parent;
        return temp.Build();
    }
}

public class MarkupFailure : MMonad
{
    private string failureMsg;

    public MarkupFailure(string fm)
    { failureMsg = fm; }

    public override MMonad _(Functor f)
    { return this; }

    public override MMonad Print()
    {
        System.Console.WriteLine(failureMsg);
        return this;
    }

    public override MMonad Out(out MMonad to)
    {
        to = new MarkupFailure("Outted from MarkupFailure");
        return this;
    }

    public override string Build()
    { return failureMsg; }
}
