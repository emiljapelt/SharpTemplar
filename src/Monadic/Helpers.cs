using System.Text;

namespace SharpTemplar.Monadic;

public delegate MarkupMonad Element(MarkupMonad monad);
public delegate Element AttributedTag(params Element[] children);
public delegate AttributedTag Tag(params ValuedAttribute[] attributes);

public delegate MarkupMonad ValuedAttribute(MarkupMonad monad);
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
    public string[] contexts { get; set; }
}

public abstract class EventInfo{};

public class InclusiveEventInfo : EventInfo
{
    public string eventName { get; set; }
    public string[] contexts { get; set; }
}

public class ExclusiveEventInfo : EventInfo
{
    public string eventName { get; set; }
    public string[] contexts { get; set; }
}

internal class TagContexts
{
    internal static readonly string[] anyContext = new string[]{};
    internal static readonly string[] bodyOnly = new string[]{"body"};
    internal static readonly string[] headOnly = new string[]{"head"};
    internal static readonly string[] formOnly = new string[]{"form"};
    internal static readonly string[] tableOnly = new string[]{"table"};
    internal static readonly string[] usualEventExclusives = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"};
}

public class Helpers
{
    public static MarkupMonad FailWith(string msg) { return new MarkupFailure(msg); }
    public static MarkupMonad FailWith(TagInfo info, string msg) { 
        var sb = new StringBuilder();
        sb.Append(msg + Environment.NewLine + "Direct contexts: [ ");
        foreach(var dc in info.directContexts) sb.Append($"{dc} ");
        sb.Append("]" + Environment.NewLine + "Contexts: [ ");
        foreach(var c in info.contexts) sb.Append($"{c} ");
        sb.Append("]");
        return new MarkupFailure(sb.ToString()); 
    }
    public static MarkupMonad FailWith(AttrInfo info, string msg) { 
        var sb = new StringBuilder();
        sb.Append(msg + Environment.NewLine + "Contexts: [ ");
        foreach(var c in info.contexts) sb.Append($"{c} ");
        sb.Append("]");
        return new MarkupFailure(sb.ToString()); 
    }
    public static MarkupMonad FailWith(EventInfo info, string msg) { 
        var sb = new StringBuilder();
        if (info is InclusiveEventInfo iei) {
            sb.Append(msg + Environment.NewLine + "Contexts: [ ");
            foreach(var c in iei.contexts) sb.Append($"{c} ");
            sb.Append("]");
        } 
        else if (info is ExclusiveEventInfo eei) {
            sb.Append(msg + Environment.NewLine + "Excluded contexts: [ ");
            foreach(var c in eei.contexts) sb.Append($"{c} ");
            sb.Append("]");
        }
        return new MarkupFailure(sb.ToString()); 
    }

    public static Tag constructTag(TagInfo info) {
        return (attrs) => (children) => (monad) => {
            if (monad is MarkupSuccess ms) {
                var dc = false;
                var c = false;

                if (info.directContexts.Length == 0) dc = true;
                foreach(string directContext in info.directContexts)
                    if(ms.pointer.tagName == directContext) { dc = true; break; }
                
                if (info.contexts.Length == 0) c = true;
                foreach(string context in info.contexts) 
                    if (ms.isInside(context)) { c = true; break; }
                
                if (dc && c) { 
                    var tag = new HTMLtag(info.tagName, ms.pointer);
                    ms.pointer.children.Add(tag);
                    var temp = ms.pointer;
                    MarkupMonad holder = ms;
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
            else return monad;
        };
    }

    public static Attribute constructAttribute(AttrInfo info)
    {
        return (input) => (monad) => {
            if (monad is MarkupSuccess m) {
                    var c = false;

                    if (info.contexts.Length == 0) c = true;
                    foreach(string context in info.contexts)
                        if(m.pointer.tagName == context) { c = true; break; }

                    if (c) { 
                        foreach(var val in input) {
                            if (info.attrName == "id") {
                                if (m.ids.Contains(val)) return FailWith($"Id '{val}' is already in use!");
                                else m.ids.Add(val);
                            }
                            m.pointer.AddAttribute(info.attrName, val); 
                        }
                        return m; 
                    }
                    return FailWith(info, $"'{info.attrName}': Attribute context failure!");
            }   
            else return monad;
        };
    }

}