using static SharpTemplar.Helpers;

namespace SharpTemplar;

public abstract class MarkupState
{
    public abstract MarkupState Print();
    public abstract string Build();
}

public class MarkupSuccess : MarkupState
{
    internal XMLtag pointer;
    internal HashSet<string> ids;

    public MarkupSuccess(XMLtag p, HashSet<string> i)
    {
        pointer = p;
        ids = i;
    }

    internal void addHTMLtag(string tagName)
    {
        var tag = new XMLtag(tagName);
        pointer.AddChild(tag);
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

    public override MarkupState Print()
    {
        var temp = pointer;
        while(temp.parent is not null) temp = temp.parent;
        temp.Print();
        return this;
    }

    public override string Build()
    {
        var temp = pointer;
        while(temp.parent is not null) temp = temp.parent;
        return temp.Build();
    }
}

public class MarkupFailure : MarkupState
{
    private string failureMsg;

    public MarkupFailure(string fm)
    { failureMsg = fm; }

    public override MarkupState Print()
    {
        System.Console.WriteLine(failureMsg);
        return this;
    }

    public override string Build()
    { return failureMsg; }
}
