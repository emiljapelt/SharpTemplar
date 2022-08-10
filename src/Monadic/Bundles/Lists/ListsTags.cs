using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Lists
{
    public static MMonad dl(this MMonad m) { return applyFunctor(Dl, m); }
    public static Functor Dl = constructTag(new TagInfo() { 
        tagName = "dl", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad dd(this MMonad m) { return applyFunctor(Dd, m); }
    public static Functor Dd = constructTag(new TagInfo() { 
        tagName = "dd", 
        contexts = new string[]{"dl"}, 
        directContexts = new string[]{}
    });

    public static MMonad dt(this MMonad m) { return applyFunctor(Dt, m); }
    public static Functor Dt = constructTag(new TagInfo() { 
        tagName = "dt", 
        contexts = new string[]{"dl"}, 
        directContexts = new string[]{}
    });

    public static MMonad ol(this MMonad m) { return applyFunctor(Ol, m); }
    public static Functor Ol = constructTag(new TagInfo() { 
        tagName = "ol", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad ul(this MMonad m) { return applyFunctor(Ul, m); }
    public static Functor Ul = constructTag(new TagInfo() { 
        tagName = "ul", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad li(this MMonad m) { return applyFunctor(Li, m); }
    public static Functor Li = constructTag(new TagInfo() { 
        tagName = "li", 
        contexts = new string[]{"ul", "ol"}, 
        directContexts = new string[]{}
    });
}