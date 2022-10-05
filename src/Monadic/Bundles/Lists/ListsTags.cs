using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Lists
{
    public static MarkupMonad dl(this MarkupMonad m) { return apply(Dl, m); }
    public static Functor Dl = constructTag(new TagInfo() { 
        tagName = "dl", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad dd(this MarkupMonad m) { return apply(Dd, m); }
    public static Functor Dd = constructTag(new TagInfo() { 
        tagName = "dd", 
        contexts = new string[]{"dl"}, 
        directContexts = anyContext
    });

    public static MarkupMonad dt(this MarkupMonad m) { return apply(Dt, m); }
    public static Functor Dt = constructTag(new TagInfo() { 
        tagName = "dt", 
        contexts = new string[]{"dl"}, 
        directContexts = anyContext
    });

    public static MarkupMonad ol(this MarkupMonad m) { return apply(Ol, m); }
    public static Functor Ol = constructTag(new TagInfo() { 
        tagName = "ol", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad ul(this MarkupMonad m) { return apply(Ul, m); }
    public static Functor Ul = constructTag(new TagInfo() { 
        tagName = "ul", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad li(this MarkupMonad m) { return apply(Li, m); }
    public static Functor Li = constructTag(new TagInfo() { 
        tagName = "li", 
        contexts = new string[]{"ul", "ol"}, 
        directContexts = anyContext
    });
}