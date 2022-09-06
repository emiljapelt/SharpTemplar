using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Base
{
    public static MMonad head(this MMonad m) { return apply(Head, m); }
    public static Functor Head = constructTag(new TagInfo() { 
        tagName = "head", 
        contexts = anyContext, 
        directContexts = new string[]{"html"}
    });

    public static MMonad body(this MMonad m) { return apply(Body, m); }
    public static Functor Body = constructTag(new TagInfo() { 
        tagName = "body", 
        contexts = anyContext, 
        directContexts = new string[]{"html"}
    });

    public static MMonad a(this MMonad m) { return apply(A, m); }
    public static Functor A = constructTag(new TagInfo() { 
        tagName = "a", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MMonad p(this MMonad m) { return apply(P, m); }
    public static Functor P = constructTag(new TagInfo() { 
        tagName = "p", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MMonad br(this MMonad m) { return apply(Br, m); }
    public static Functor Br = (monad) => {
        constructTag(new TagInfo() { 
            tagName = "br", 
            contexts = bodyOnly, 
            directContexts = anyContext
        })(monad);
        monad.newest = null;
        return monad;
    };

    public static MMonad button(this MMonad m) { return apply(Button, m); }
    public static Functor Button = constructTag(new TagInfo() { 
        tagName = "button", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MMonad div(this MMonad m) { return apply(Div, m); }
    public static Functor Div = constructTag(new TagInfo() { 
        tagName = "div", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MMonad span(this MMonad m) { return apply(Span, m); }
    public static Functor Span = constructTag(new TagInfo() { 
        tagName = "span", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MMonad main(this MMonad m) { return apply(Main, m); }
    public static Functor Main = constructTag(new TagInfo() { 
        tagName = "main", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MMonad header(this MMonad m) { return apply(Header, m); }
    public static Functor Header = constructTag(new TagInfo() { 
        tagName = "header", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MMonad footer(this MMonad m) { return apply(Footer, m); }
    public static Functor Footer = constructTag(new TagInfo() { 
        tagName = "footer", 
        contexts = bodyOnly,
        directContexts = anyContext
    });

    public static MMonad script(this MMonad m) { return apply(Script, m); }
    public static Functor Script = constructTag(new TagInfo() { 
        tagName = "script", 
        contexts = anyContext, 
        directContexts = anyContext
    });

    public static MMonad section(this MMonad m) { return apply(Section, m); }
    public static Functor Section = constructTag(new TagInfo() { 
        tagName = "section", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });
}