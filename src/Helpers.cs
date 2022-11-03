using System.Text;

namespace SharpTemplar;

public delegate MarkupState Element(MarkupState state);
public delegate Element AttributedTag(params Element[] children);
public delegate AttributedTag Tag(params ValuedAttribute[] attributes);

public delegate MarkupState ValuedAttribute(MarkupState state);
public delegate ValuedAttribute Attribute(params string[] values);

public class TagInfo
{
    public string tagName { get; set; }
    public string[] directContexts { get; set; }
    public string[] contexts { get; set; }
}

public class AttrInfo
{
    public string attrName { get; set; }
    public Contexts contexts { get; set; }
}

public abstract class Contexts
{
    private readonly string[] contexts;
    public virtual string[] get() { return contexts; }
    public Contexts(string[] cs) { contexts = cs; }
}

public class InclusiveContexts : Contexts
{
    public override string[] get() { return base.get(); }
    public InclusiveContexts(string[] cs) : base(cs) { } 
}

public class ExclusiveContexts : Contexts
{
    public override string[] get() { return base.get(); }
    public ExclusiveContexts(string[] cs) : base(cs) { } 
}

public class Helpers
{
    public static MarkupState FailWith(string msg) { return new MarkupFailure(msg); }
    public static MarkupState FailWith(TagInfo info, string msg) { 
        var sb = new StringBuilder();
        sb.Append(msg + Environment.NewLine + "Direct contexts: [ ");
        foreach(var dc in info.directContexts) sb.Append($"{dc} ");
        sb.Append("]" + Environment.NewLine + "Contexts: [ ");
        foreach(var c in info.contexts) sb.Append($"{c} ");
        sb.Append("]");
        return new MarkupFailure(sb.ToString()); 
    }
    public static MarkupState FailWith(AttrInfo info, string msg) { 
        var sb = new StringBuilder();
        if (info.contexts is InclusiveContexts icc) {
            sb.Append(msg + Environment.NewLine + "Included contexts: [ ");
            foreach(var c in icc.get()) sb.Append($"{c} ");
            sb.Append("]");
        }
        else if (info.contexts is ExclusiveContexts exc) {
            sb.Append(msg + Environment.NewLine + "Excluded contexts: [ ");
            foreach(var c in exc.get()) sb.Append($"{c} ");
            sb.Append("]");
        }
        return new MarkupFailure(sb.ToString()); 
    }

    public static Tag constructTag(TagInfo info) {
        return (attrs) => (children) => (state) => {
            if (state is MarkupSuccess ms) {
                var dc = false;
                var c = false;

                if (info.directContexts.Length == 0) dc = true;
                foreach(string directContext in info.directContexts)
                    if(ms.pointer.tagName == directContext) { dc = true; break; }
                
                if (info.contexts.Length == 0) c = true;
                foreach(string context in info.contexts) 
                    if (ms.isInside(context)) { c = true; break; }
                
                if (dc && c) { 
                    var tag = new XMLtag(info.tagName, ms.pointer);
                    ms.pointer.children.Add(tag);
                    var temp = ms.pointer;
                    MarkupState holder = ms;
                    foreach(var attr in attrs) {
                        ms.pointer = tag;
                        holder = attr(holder);
                        if (holder is MarkupFailure) return holder;
                    }
                    foreach(var child in children) {
                        ms.pointer = tag;
                        holder = child(holder);
                        if (holder is MarkupFailure) return holder;
                    }
                    ms.pointer = temp;
                    return holder;
                }
                return FailWith(info, $"'{info.tagName}': Tag context failure!");
            }
            else return state;
        };
    }

    public static Attribute constructAttribute(AttrInfo info)
    {
        if (info.contexts is InclusiveContexts inc) {
            return (input) => (state) => {
                if (state is MarkupSuccess ms) {
                        var c = false;

                        if (inc.get().Length == 0) c = true;
                        foreach(string context in inc.get())
                            if(ms.pointer.tagName == context) { c = true; break; }

                        if (c) { 
                            foreach(var val in input) {
                                if (info.attrName == "id") {
                                    if (ms.ids.Contains(val)) return FailWith($"Id '{val}' is already in use!");
                                    else ms.ids.Add(val);
                                }
                                ms.pointer.AddAttribute(info.attrName, val); 
                            }
                            return ms; 
                        }
                        return FailWith(info, $"'{info.attrName}': Attribute context failure!");
                }   
                else return state;
            };
        }
        else if (info.contexts is ExclusiveContexts exc) {
            return (input) => (state) => {
                if (state is MarkupSuccess ms) {
                        var c = true;

                        if (exc.get().Length == 0) c = true;
                        foreach(string context in exc.get())
                            if(ms.pointer.tagName == context) { c = false; break; }

                        if (c) { 
                            foreach(var val in input) {
                                if (info.attrName == "id") {
                                    if (ms.ids.Contains(val)) return FailWith($"Id '{val}' is already in use!");
                                    else ms.ids.Add(val);
                                }
                                ms.pointer.AddAttribute(info.attrName, val); 
                            }
                            return ms; 
                        }
                        return FailWith(info, $"'{info.attrName}': Attribute context failure!");
                }   
                else return state;
            };
        }
        else return (i) => (s) => new MarkupFailure("Unknown attribute type!");
    }

}