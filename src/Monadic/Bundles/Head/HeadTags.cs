using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Head
{
    public static MMonad basis(this MMonad m) { return applyFunctor(Basis, m); }
    public static Functor Basis = constructTag(new TagInfo() { 
        tagName = "base", 
        contexts = anyContext, 
        directContexts = headOnly
    });

    public static MMonad link(this MMonad m) { return applyFunctor(Link, m); }
    public static Functor Link = constructTag(new TagInfo() { 
        tagName = "link", 
        contexts = anyContext, 
        directContexts = headOnly
    });

    public static MMonad meta(this MMonad m) { return applyFunctor(Meta, m); }
    public static Functor Meta = constructTag(new TagInfo() { 
        tagName = "meta", 
        contexts = anyContext, 
        directContexts = headOnly
    });

    public static MMonad style(this MMonad m) { return applyFunctor(Style, m); }
    public static Functor Style = constructTag(new TagInfo() { 
        tagName = "style", 
        contexts = anyContext, 
        directContexts = headOnly
    });

    public static MMonad title(this MMonad m) { return applyFunctor(Title, m); }
    public static Functor Title = constructTag(new TagInfo() { 
        tagName = "title", 
        contexts = anyContext, 
        directContexts = headOnly
    });
}