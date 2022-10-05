using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Head
{
    public static MarkupMonad basis(this MarkupMonad m) { return apply(Basis, m); }
    public static Functor Basis = constructTag(new TagInfo() { 
        tagName = "base", 
        contexts = anyContext, 
        directContexts = headOnly
    });

    public static MarkupMonad link(this MarkupMonad m) { return apply(Link, m); }
    public static Functor Link = constructTag(new TagInfo() { 
        tagName = "link", 
        contexts = anyContext, 
        directContexts = headOnly
    });

    public static MarkupMonad meta(this MarkupMonad m) { return apply(Meta, m); }
    public static Functor Meta = constructTag(new TagInfo() { 
        tagName = "meta", 
        contexts = anyContext, 
        directContexts = headOnly
    });

    public static MarkupMonad style(this MarkupMonad m) { return apply(Style, m); }
    public static Functor Style = constructTag(new TagInfo() { 
        tagName = "style", 
        contexts = anyContext, 
        directContexts = headOnly
    });

    public static MarkupMonad title(this MarkupMonad m) { return apply(Title, m); }
    public static Functor Title = constructTag(new TagInfo() { 
        tagName = "title", 
        contexts = anyContext, 
        directContexts = headOnly
    });
}