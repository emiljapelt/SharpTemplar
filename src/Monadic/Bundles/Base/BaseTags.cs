using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Base
{
    public static MMonad head(this MMonad m) { return applyFunctor(Head, m); }
    public static Functor Head = constructTag(new TagInfo() { 
        tagName = "head", 
        contexts = new string[]{}, 
        directContexts = new string[]{"html"}
    });

    public static MMonad body(this MMonad m) { return applyFunctor(Body, m); }
    public static Functor Body = constructTag(new TagInfo() { 
        tagName = "body", 
        contexts = new string[]{}, 
        directContexts = new string[]{"html"}
    });

    public static MMonad a(this MMonad m) { return applyFunctor(A, m); }
    public static Functor A = constructTag(new TagInfo() { 
        tagName = "a", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad p(this MMonad m) { return applyFunctor(P, m); }
    public static Functor P = constructTag(new TagInfo() { 
        tagName = "p", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad br(this MMonad m) { return applyFunctor(Br, m); }
    public static Functor Br = (monad) => {
        constructTag(new TagInfo() { 
            tagName = "br", 
            contexts = new string[]{"body"}, 
            directContexts = new string[]{}
        })(monad);
        monad.newest = null;
        return monad;
    };

    public static MMonad button(this MMonad m) { return applyFunctor(Button, m); }
    public static Functor Button = constructTag(new TagInfo() { 
        tagName = "button", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad div(this MMonad m) { return applyFunctor(Div, m); }
    public static Functor Div = constructTag(new TagInfo() { 
        tagName = "div", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad span(this MMonad m) { return applyFunctor(Span, m); }
    public static Functor Span = constructTag(new TagInfo() { 
        tagName = "span", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad main(this MMonad m) { return applyFunctor(Main, m); }
    public static Functor Main = constructTag(new TagInfo() { 
        tagName = "main", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad header(this MMonad m) { return applyFunctor(Header, m); }
    public static Functor Header = constructTag(new TagInfo() { 
        tagName = "header", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad footer(this MMonad m) { return applyFunctor(Footer, m); }
    public static Functor Footer = constructTag(new TagInfo() { 
        tagName = "footer", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad script(this MMonad m) { return applyFunctor(Script, m); }
    public static Functor Script = constructTag(new TagInfo() { 
        tagName = "script", 
        contexts = new string[]{}, 
        directContexts = new string[]{}
    });

    public static MMonad section(this MMonad m) { return applyFunctor(Section, m); }
    public static Functor Section = constructTag(new TagInfo() { 
        tagName = "section", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });
}