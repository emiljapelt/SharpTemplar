using static SharpTemplar.Monadic.Helpers;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SharpTemplar.Test")]
namespace SharpTemplar.Monadic;

public abstract class MarkupMonad
{
    // public abstract MarkupMonad _(Functor f);
    public abstract MarkupMonad Print();
    public abstract string Build();
    public abstract MarkupMonad Out(out MarkupMonad to);
}

public class MarkupSuccess : MarkupMonad
{
    internal HTMLtag pointer;
    internal HTMLtag newest;
    internal HashSet<string> ids;

    public MarkupSuccess(HTMLtag p, HashSet<string> i)
    {
        pointer = p;
        ids = i;
    }

    internal void addHTMLtag(string tagName)
    {
        var tag = new HTMLtag(tagName);
        pointer.AddChild(tag);
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

    internal MarkupMonad newestOrCurrent(Func<HTMLtag, MarkupMonad> f) 
    {
        if (newest is null) return f(pointer); 
        else return f(newest);
    }

    // public override MarkupMonad _(Functor f)
    // {
    //     return f(this);
    // }

    public override MarkupMonad Print()
    {
        var temp = pointer;
        while(temp.parent is not null) temp = temp.parent;
        temp.Print();
        return this;
    }

    public override MarkupMonad Out(out MarkupMonad to)
    {
        if (newest is not null) to = new MarkupSuccess(newest, ids);
        else to = new MarkupSuccess(pointer, ids);
        return this;
    }

    public override string Build()
    {
        var temp = pointer;
        while(temp.parent is not null) temp = temp.parent;
        return temp.Build();
    }
}

public class MarkupFailure : MarkupMonad
{
    private string failureMsg;

    public MarkupFailure(string fm)
    { failureMsg = fm; }

    // public override MarkupMonad _(Functor f)
    // { return this; }

    public override MarkupMonad Print()
    {
        System.Console.WriteLine(failureMsg);
        return this;
    }

    public override MarkupMonad Out(out MarkupMonad to)
    {
        to = new MarkupFailure("Outted from MarkupFailure");
        return this;
    }

    public override string Build()
    { return failureMsg; }
}
