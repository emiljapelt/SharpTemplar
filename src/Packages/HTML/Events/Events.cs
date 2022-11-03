using static SharpTemplar.Helpers;
using static SharpTemplar.HyperText.TagContexts;

namespace SharpTemplar.HyperText;

public static partial class Events
{
    public static ValuedAttribute @on(EventInfo info, string call)
    {
        return constructAttribute(new AttrInfo() {
            attrName = $"on{info.eventName}",
            contexts = info.contexts
        })(call);
    }

    private static readonly string[] usualEventExclusives = new string[]{"base", "bdo", "br", "head", "html", "iframe", "meta", "param", "script", "style", "title"};


    // Window events
    public static EventInfo afterprint = new EventInfo() { eventName = "afterprint", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo beforeprint = new EventInfo() { eventName = "beforeprint", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo beforeupload = new EventInfo() { eventName = "beforeupload", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo error = new EventInfo() { eventName = "error", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo hashchange = new EventInfo() { eventName = "hashchange", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo load = new EventInfo() { eventName = "load", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo message = new EventInfo() { eventName = "message", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo offline = new EventInfo() { eventName = "offline", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo online = new EventInfo() { eventName = "online", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo pagehide = new EventInfo() { eventName = "pagehide", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo pageshow = new EventInfo() { eventName = "pageshow", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo popstate = new EventInfo() { eventName = "popstate", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo resize = new EventInfo() { eventName = "resize", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo storage = new EventInfo() { eventName = "storage", contexts = new InclusiveContexts(bodyOnly) };
    public static EventInfo unload = new EventInfo() { eventName = "unload", contexts = new InclusiveContexts(bodyOnly) };

    // Form events
    public static EventInfo blur = new EventInfo() { eventName = "blur", contexts = new ExclusiveContexts(usualEventExclusives) };
    public static EventInfo change = new EventInfo() { eventName = "change", contexts = new InclusiveContexts(new string[]{"input", "select", "textarea"}) };
    public static EventInfo contextmenu = new EventInfo() { eventName = "contextmenu", contexts = new InclusiveContexts(new string[]{}) };
    public static EventInfo focus = new EventInfo() { eventName = "focus", contexts = new ExclusiveContexts(usualEventExclusives) };
    public static EventInfo input = new EventInfo() { eventName = "input", contexts = new InclusiveContexts(new string[]{"input", "textarea"}) };
    public static EventInfo invalid = new EventInfo() { eventName = "invalid", contexts = new InclusiveContexts(new string[]{"input"}) };
    public static EventInfo reset = new EventInfo() { eventName = "reset", contexts = new InclusiveContexts(new string[]{"form"}) };
    public static EventInfo select = new EventInfo() { eventName = "select", contexts = new InclusiveContexts(new string[]{"input", "textarea"}) };
    public static EventInfo submit = new EventInfo() { eventName = "submit", contexts = new InclusiveContexts(new string[]{"form"}) };
    
    // Keyboard events
    public static EventInfo keydown = new EventInfo() { eventName = "keydown", contexts = new ExclusiveContexts(usualEventExclusives) };
    public static EventInfo keypress = new EventInfo() { eventName = "keypress", contexts = new ExclusiveContexts(usualEventExclusives) };
    public static EventInfo keyup = new EventInfo() { eventName = "keyup", contexts = new ExclusiveContexts(usualEventExclusives) };

    // Mouse events
    public static EventInfo click = new EventInfo() { eventName = "click", contexts = new ExclusiveContexts(usualEventExclusives) };
    public static EventInfo dblclick = new EventInfo() { eventName = "dblclick", contexts = new ExclusiveContexts(usualEventExclusives) };
    public static EventInfo mousedown = new EventInfo() { eventName = "mousedown", contexts = new ExclusiveContexts(usualEventExclusives) };
    public static EventInfo mousemove = new EventInfo() { eventName = "mousemove", contexts = new ExclusiveContexts(usualEventExclusives) };
    public static EventInfo mouseout = new EventInfo() { eventName = "mouseout", contexts = new ExclusiveContexts(usualEventExclusives) };
    public static EventInfo mouseover = new EventInfo() { eventName = "mouseover", contexts = new ExclusiveContexts(usualEventExclusives) };
    public static EventInfo mouseup = new EventInfo() { eventName = "mouseup", contexts = new ExclusiveContexts(usualEventExclusives) };
    public static EventInfo wheel = new EventInfo() { eventName = "wheel", contexts = new ExclusiveContexts(usualEventExclusives) };

    // Drag events
    public static EventInfo drag = new EventInfo() { eventName = "drag", contexts = new InclusiveContexts(anyContext) };
    public static EventInfo dragend = new EventInfo() { eventName = "dragend", contexts = new InclusiveContexts(anyContext) };
    public static EventInfo dragenter = new EventInfo() { eventName = "dragenter", contexts = new InclusiveContexts(anyContext) };
    public static EventInfo dragleave = new EventInfo() { eventName = "dragleave", contexts = new InclusiveContexts(anyContext) };
    public static EventInfo dragover = new EventInfo() { eventName = "dragover", contexts = new InclusiveContexts(anyContext) };
    public static EventInfo dragstart = new EventInfo() { eventName = "dragstart", contexts = new InclusiveContexts(anyContext) };
    public static EventInfo drop = new EventInfo() { eventName = "drop", contexts = new InclusiveContexts(anyContext) };
    public static EventInfo scroll = new EventInfo() { eventName = "scroll", contexts = new InclusiveContexts(anyContext) };

    // Clipboard events
    public static EventInfo copy = new EventInfo() { eventName = "copy", contexts = new InclusiveContexts(anyContext) };
    public static EventInfo cut = new EventInfo() { eventName = "cut", contexts = new InclusiveContexts(anyContext) };
    public static EventInfo paste = new EventInfo() { eventName = "paste", contexts = new InclusiveContexts(anyContext) };

}