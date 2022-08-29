using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Events
{
    public static MMonad @on(this MMonad m, EventInfo info, string call) { return applyFunctor(@On(info, call), m); }
    public static Functor @On(EventInfo info, string call)
    {
        if (info is InclusiveEventInfo iei) {
            return (monad) => {
                if (monad is MarkupMonad m) {
                    return m.newestOrCurrent((tag) => {
                        var c = false;

                        if (iei.contexts.Length == 0) c = true;
                        foreach(string context in iei.contexts)
                            if(tag.tagName == context) { c = true; break; }

                        if (c) { tag.AddAttribute("on" + iei.eventName, call); return m; }
                        return FailWith($"'{iei.eventName}': Event context failure!");
                    });
                }   
                else return monad;
            };
        }
        else if (info is ExclusiveEventInfo eei) {
            return (monad) => {
                if (monad is MarkupMonad m) {
                    return m.newestOrCurrent((tag) => {
                        var c = true;

                        foreach(string context in eei.contexts)
                            if(tag.tagName == context) { c = false; break; }

                        if (c) { tag.AddAttribute("on" + eei.eventName, call); return m; }
                        return FailWith(info, $"'{eei.eventName}': Event context failure!");
                    });
                }   
                else return monad;
            };
        }
        else return (monad) => new MarkupFailure("Unknown EventInfo type!");
    }

    // Window events
    public static EventInfo afterprint = new InclusiveEventInfo() { eventName = "afterprint", contexts = new string[]{"body"} };
    public static EventInfo beforeprint = new InclusiveEventInfo() { eventName = "beforeprint", contexts = new string[]{"body"} };
    public static EventInfo beforeupload = new InclusiveEventInfo() { eventName = "beforeupload", contexts = new string[]{"body"} };
    public static EventInfo error = new InclusiveEventInfo() { eventName = "error", contexts = new string[]{"body"} };
    public static EventInfo hashchange = new InclusiveEventInfo() { eventName = "hashchange", contexts = new string[]{"body"} };
    public static EventInfo load = new InclusiveEventInfo() { eventName = "load", contexts = new string[]{"body"} };
    public static EventInfo message = new InclusiveEventInfo() { eventName = "message", contexts = new string[]{"body"} };
    public static EventInfo offline = new InclusiveEventInfo() { eventName = "offline", contexts = new string[]{"body"} };
    public static EventInfo online = new InclusiveEventInfo() { eventName = "online", contexts = new string[]{"body"} };
    public static EventInfo pagehide = new InclusiveEventInfo() { eventName = "pagehide", contexts = new string[]{"body"} };
    public static EventInfo pageshow = new InclusiveEventInfo() { eventName = "pageshow", contexts = new string[]{"body"} };
    public static EventInfo popstate = new InclusiveEventInfo() { eventName = "popstate", contexts = new string[]{"body"} };
    public static EventInfo resize = new InclusiveEventInfo() { eventName = "resize", contexts = new string[]{"body"} };
    public static EventInfo storage = new InclusiveEventInfo() { eventName = "storage", contexts = new string[]{"body"} };
    public static EventInfo unload = new InclusiveEventInfo() { eventName = "unload", contexts = new string[]{"body"} };

    // Form events
    public static EventInfo blur = new ExclusiveEventInfo() { eventName = "blur", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };
    public static EventInfo change = new InclusiveEventInfo() { eventName = "change", contexts = new string[]{"input", "select", "textarea"} };
    public static EventInfo contextmenu = new InclusiveEventInfo() { eventName = "contextmenu", contexts = new string[]{} };
    public static EventInfo focus = new ExclusiveEventInfo() { eventName = "focus", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };
    public static EventInfo input = new InclusiveEventInfo() { eventName = "input", contexts = new string[]{"input", "textarea"} };
    public static EventInfo invalid = new InclusiveEventInfo() { eventName = "invalid", contexts = new string[]{"input"} };
    public static EventInfo reset = new InclusiveEventInfo() { eventName = "reset", contexts = new string[]{"form"} };
    public static EventInfo select = new InclusiveEventInfo() { eventName = "select", contexts = new string[]{"input", "textarea"} };
    public static EventInfo submit = new InclusiveEventInfo() { eventName = "submit", contexts = new string[]{"form"} };
    
    // Keyboard events
    public static EventInfo keydown = new ExclusiveEventInfo() { eventName = "keydown", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };
    public static EventInfo keypress = new ExclusiveEventInfo() { eventName = "keypress", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };
    public static EventInfo keyup = new ExclusiveEventInfo() { eventName = "keyup", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };

    // Mouse events
    public static EventInfo click = new ExclusiveEventInfo() { eventName = "click", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };
    public static EventInfo dblclick = new ExclusiveEventInfo() { eventName = "dblclick", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };
    public static EventInfo mousedown = new ExclusiveEventInfo() { eventName = "mousedown", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };
    public static EventInfo mousemove = new ExclusiveEventInfo() { eventName = "mousemove", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };
    public static EventInfo mouseout = new ExclusiveEventInfo() { eventName = "mouseout", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };
    public static EventInfo mouseover = new ExclusiveEventInfo() { eventName = "mouseover", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };
    public static EventInfo mouseup = new ExclusiveEventInfo() { eventName = "mouseup", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };
    public static EventInfo wheel = new ExclusiveEventInfo() { eventName = "wheel", contexts = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"} };

    // Drag events
    public static EventInfo drag = new InclusiveEventInfo() { eventName = "drag", contexts = new string[]{} };
    public static EventInfo dragend = new InclusiveEventInfo() { eventName = "dragend", contexts = new string[]{} };
    public static EventInfo dragenter = new InclusiveEventInfo() { eventName = "dragenter", contexts = new string[]{} };
    public static EventInfo dragleave = new InclusiveEventInfo() { eventName = "dragleave", contexts = new string[]{} };
    public static EventInfo dragover = new InclusiveEventInfo() { eventName = "dragover", contexts = new string[]{} };
    public static EventInfo dragstart = new InclusiveEventInfo() { eventName = "dragstart", contexts = new string[]{} };
    public static EventInfo drop = new InclusiveEventInfo() { eventName = "drop", contexts = new string[]{} };
    public static EventInfo scroll = new InclusiveEventInfo() { eventName = "scroll", contexts = new string[]{} };

    // Clipboard events
    public static EventInfo copy = new InclusiveEventInfo() { eventName = "copy", contexts = new string[]{} };
    public static EventInfo cut = new InclusiveEventInfo() { eventName = "cut", contexts = new string[]{} };
    public static EventInfo paste = new InclusiveEventInfo() { eventName = "paste", contexts = new string[]{} };


}