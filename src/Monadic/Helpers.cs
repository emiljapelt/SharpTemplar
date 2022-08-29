using System.Text;

namespace SharpTemplar.Monadic;

public delegate MMonad Functor(MarkupMonad m);

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

public class Helpers
{
    public static MMonad FailWith(string msg) { return new MarkupFailure(msg); }
    public static MMonad FailWith(TagInfo info, string msg) { 
        var sb = new StringBuilder();
        sb.Append(msg + Environment.NewLine + "Direct contexts: [ ");
        foreach(var dc in info.directContexts) sb.Append($"{dc} ");
        sb.Append("]" + Environment.NewLine + "Contexts: [ ");
        foreach(var c in info.contexts) sb.Append($"{c} ");
        sb.Append("]");
        return new MarkupFailure(sb.ToString()); 
    }
    public static MMonad FailWith(AttrInfo info, string msg) { 
        var sb = new StringBuilder();
        sb.Append(msg + Environment.NewLine + "Contexts: [ ");
        foreach(var c in info.contexts) sb.Append($"{c} ");
        sb.Append("]");
        return new MarkupFailure(sb.ToString()); 
    }
    public static MMonad FailWith(EventInfo info, string msg) { 
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

    public static MMonad applyFunctor(Functor f, MMonad target) {
        if (target is MarkupMonad m) return f(m);
        else return target;
    }

    public static Functor constructTag(TagInfo info)
    {
        return (monad) => {
            if (monad is MarkupMonad m) {
                var dc = false;
                var c = false;

                if (info.directContexts.Length == 0) dc = true;
                foreach(string directContext in info.directContexts)
                    if(m.pointer.tagName == directContext) { dc = true; break; }
                
                if (info.contexts.Length == 0) c = true;
                foreach(string context in info.contexts) 
                    if (m.isInside(context)) { c = true; break; }
                
                if (dc && c) { m.addHTMLtag(info.tagName); return m; }
                return FailWith(info, $"'{info.tagName}': Tag context failure!");
            }
            else return monad;
        };
    }

    public static Func<string, Functor> constructAttribute(AttrInfo info)
    {
        return (input) => (monad) => {
            if (monad is MarkupMonad m) {
                return m.newestOrCurrent((tag) => {
                    var c = false;

                    if (info.contexts.Length == 0) c = true;
                    foreach(string context in info.contexts)
                        if(tag.tagName == context) { c = true; break; }

                    if (c) { tag.AddAttribute(info.attrName, input); return m; }
                    return FailWith(info, $"'{info.attrName}': Attribute context failure!");
                });
            }   
            else return monad;
        };
    }
}