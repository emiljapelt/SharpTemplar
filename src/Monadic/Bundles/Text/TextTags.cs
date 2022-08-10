using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Text
{
    public static MMonad abbr(this MMonad m) { return applyFunctor(Abbr, m); }
    public static Functor Abbr = constructTag(new TagInfo() { 
        tagName = "abbr", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad address(this MMonad m) { return applyFunctor(Address, m); }
    public static Functor Address = constructTag(new TagInfo() { 
        tagName = "address", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad bdi(this MMonad m) { return applyFunctor(Bdi, m); }
    public static Functor Bdi = constructTag(new TagInfo() { 
        tagName = "bdi", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad bdo(this MMonad m) { return applyFunctor(Bdo, m); }
    public static Functor Bdo = constructTag(new TagInfo() { 
        tagName = "bdo", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad blockquote(this MMonad m) { return applyFunctor(Blockquote, m); }
    public static Functor Blockquote = constructTag(new TagInfo() { 
        tagName = "blockquote", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad q(this MMonad m) { return applyFunctor(Q, m); }
    public static Functor Q = constructTag(new TagInfo() { 
        tagName = "q", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad cite(this MMonad m) { return applyFunctor(Cite, m); }
    public static Functor Cite = constructTag(new TagInfo() { 
        tagName = "cite", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad code(this MMonad m) { return applyFunctor(Code, m); }
    public static Functor Code = constructTag(new TagInfo() { 
        tagName = "code", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad del(this MMonad m) { return applyFunctor(Del, m); }
    public static Functor Del = constructTag(new TagInfo() { 
        tagName = "del", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad details(this MMonad m) { return applyFunctor(Details, m); }
    public static Functor Details = constructTag(new TagInfo() { 
        tagName = "details", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad summary(this MMonad m) { return applyFunctor(Summary, m); }
    public static Functor Summary = constructTag(new TagInfo() { 
        tagName = "summary", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad em(this MMonad m) { return applyFunctor(Em, m); }
    public static Functor Em = constructTag(new TagInfo() { 
        tagName = "em", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad h(this MMonad m, int level) { return applyFunctor(H(level), m); }
    public static Func<int, Functor> H = (int level) => (monad) => {
        if (level < 0 || 6 > level) return FailWith("Header level must be between 1 and 6!");
        return constructTag(new TagInfo() { 
            tagName = $"h{level}", 
            contexts = new string[]{"body"}, 
            directContexts = new string[]{}
        })(monad);
    };

    public static MMonad i(this MMonad m) { return applyFunctor(I, m); }
    public static Functor I = constructTag(new TagInfo() { 
        tagName = "i", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad ins(this MMonad m) { return applyFunctor(Ins, m); }
    public static Functor Ins = constructTag(new TagInfo() { 
        tagName = "ins", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad mark(this MMonad m) { return applyFunctor(Mark, m); }
    public static Functor Mark = constructTag(new TagInfo() { 
        tagName = "mark", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad s(this MMonad m) { return applyFunctor(S, m); }
    public static Functor S = constructTag(new TagInfo() { 
        tagName = "s", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad small(this MMonad m) { return applyFunctor(Small, m); }
    public static Functor Small = constructTag(new TagInfo() { 
        tagName = "small", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad strong(this MMonad m) { return applyFunctor(Strong, m); }
    public static Functor Strong = constructTag(new TagInfo() { 
        tagName = "strong", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad sub(this MMonad m) { return applyFunctor(Sub, m); }
    public static Functor Sub = constructTag(new TagInfo() { 
        tagName = "sub", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad sup(this MMonad m) { return applyFunctor(Sup, m); }
    public static Functor Sup = constructTag(new TagInfo() { 
        tagName = "sup", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad time(this MMonad m) { return applyFunctor(Time, m); }
    public static Functor Time = constructTag(new TagInfo() { 
        tagName = "time", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad u(this MMonad m) { return applyFunctor(U, m); }
    public static Functor U = constructTag(new TagInfo() { 
        tagName = "u", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });
}