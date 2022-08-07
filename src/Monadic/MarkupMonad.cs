using static SharpTemplar.Monadic.NavigationCommand;

namespace SharpTemplar.Monadic;

public abstract class MMonad
{
    public abstract MMonad _(NavigationCommand command);
    public abstract MMonad _(CreationCommand command);
    public abstract MMonad _(ArgumentCommand command, string input);
    public abstract MMonad _(ParamsCommand command, params string[] inputs);
    public abstract MMonad Print();
    public abstract string Build();
    public abstract MMonad Out(out MMonad to);
}


public class MarkupMonad : MMonad
{
    private HTMLtag pointer;
    private HTMLtag newest;
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

    public static MMonad FailWith(string msg) 
    {
        return new MarkupFailure(msg);
    }

    public override MMonad _(NavigationCommand command)
    {
        switch(command) {
            case enter:
                if (newest is null) return FailWith("No newest added element to Enter!");
                else return new MarkupMonad(newest, ids);
            case exit:
                if (pointer.parent is null) return FailWith("No parent to Exit to!");
                else return new MarkupMonad(pointer.parent, ids);
            default:
                throw new System.Exception("Unknown command");
        }
    }

    private void addHTMLtag(string tagName)
    {
        var tag = new HTMLtag(tagName, pointer);
        pointer.children.Add(tag);
        newest = tag;
    }

    private bool isInside(string tagName)
    {
        var temp = pointer;
        while(true) {
            if (temp.tagName == tagName) return true;
            if (temp.parent is null) return false;
            temp = temp.parent;
        }
    }

    public override MMonad _(CreationCommand tag)
    {
        var dc = false;
        var c = false;

        if (tag.directContexts.Length == 0) dc = true;
        foreach(string directContext in tag.directContexts)
            if( pointer.tagName == directContext ) dc = true;
        
        if (tag.contexts.Length == 0) c = true;
        foreach(string context in tag.contexts) 
            if (isInside(context)) c = true;
        
        if (dc && c) { addHTMLtag(tag.tagName); return this; }
        return FailWith($"'{tag.tagName}': Context failure!");
    }

    public MMonad newestOrCurrent(Func<HTMLtag, MMonad> f) {
        if (newest is null) return f(pointer); 
        else return f(newest);
    }

    public override MMonad _(ArgumentCommand command, string input)
    {
        return newestOrCurrent(command(this, input));
    }

    public override MMonad _(ParamsCommand command, params string[] inputs)
    {
        return newestOrCurrent(command(this, inputs));
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
    {
        failureMsg = fm;
    }

    public override MMonad _(NavigationCommand command)
    { return this; }
    public override MMonad _(CreationCommand command)
    { return this; }
    public override MMonad _(ArgumentCommand command, string input)
    { return this; }
    public override MMonad _(ParamsCommand command, params string[] inputs)
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
    {
        return failureMsg;
    }
}
