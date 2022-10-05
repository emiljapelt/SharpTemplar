using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Text
{
    public static MarkupMonad abbr(this MarkupMonad m) { return apply(Abbr, m); }
    public static Functor Abbr = constructTag(new TagInfo() { 
        tagName = "abbr", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad address(this MarkupMonad m) { return apply(Address, m); }
    public static Functor Address = constructTag(new TagInfo() { 
        tagName = "address", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad bdi(this MarkupMonad m) { return apply(Bdi, m); }
    public static Functor Bdi = constructTag(new TagInfo() { 
        tagName = "bdi", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad bdo(this MarkupMonad m) { return apply(Bdo, m); }
    public static Functor Bdo = constructTag(new TagInfo() { 
        tagName = "bdo", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad blockquote(this MarkupMonad m) { return apply(Blockquote, m); }
    public static Functor Blockquote = constructTag(new TagInfo() { 
        tagName = "blockquote", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad q(this MarkupMonad m) { return apply(Q, m); }
    public static Functor Q = constructTag(new TagInfo() { 
        tagName = "q", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad cite(this MarkupMonad m) { return apply(Cite, m); }
    public static Functor Cite = constructTag(new TagInfo() { 
        tagName = "cite", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad code(this MarkupMonad m) { return apply(Code, m); }
    public static Functor Code = constructTag(new TagInfo() { 
        tagName = "code", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad del(this MarkupMonad m) { return apply(Del, m); }
    public static Functor Del = constructTag(new TagInfo() { 
        tagName = "del", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad details(this MarkupMonad m) { return apply(Details, m); }
    public static Functor Details = constructTag(new TagInfo() { 
        tagName = "details", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad summary(this MarkupMonad m) { return apply(Summary, m); }
    public static Functor Summary = constructTag(new TagInfo() { 
        tagName = "summary", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad em(this MarkupMonad m) { return apply(Em, m); }
    public static Functor Em = constructTag(new TagInfo() { 
        tagName = "em", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad h(this MarkupMonad m, int level) { return apply(H(level), m); }
    public static Func<int, Functor> H = (int level) => (monad) => {
        if (level < 0 || 6 < level) return FailWith("Header level must be between 1 and 6!");
        return constructTag(new TagInfo() { 
            tagName = $"h{level}", 
            contexts = bodyOnly, 
            directContexts = anyContext
        })(monad);
    };

    public static MarkupMonad i(this MarkupMonad m) { return apply(I, m); }
    public static Functor I = constructTag(new TagInfo() { 
        tagName = "i", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad ins(this MarkupMonad m) { return apply(Ins, m); }
    public static Functor Ins = constructTag(new TagInfo() { 
        tagName = "ins", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad mark(this MarkupMonad m) { return apply(Mark, m); }
    public static Functor Mark = constructTag(new TagInfo() { 
        tagName = "mark", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad s(this MarkupMonad m) { return apply(S, m); }
    public static Functor S = constructTag(new TagInfo() { 
        tagName = "s", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad small(this MarkupMonad m) { return apply(Small, m); }
    public static Functor Small = constructTag(new TagInfo() { 
        tagName = "small", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad strong(this MarkupMonad m) { return apply(Strong, m); }
    public static Functor Strong = constructTag(new TagInfo() { 
        tagName = "strong", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad sub(this MarkupMonad m) { return apply(Sub, m); }
    public static Functor Sub = constructTag(new TagInfo() { 
        tagName = "sub", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad sup(this MarkupMonad m) { return apply(Sup, m); }
    public static Functor Sup = constructTag(new TagInfo() { 
        tagName = "sup", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad time(this MarkupMonad m) { return apply(Time, m); }
    public static Functor Time = constructTag(new TagInfo() { 
        tagName = "time", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad u(this MarkupMonad m) { return apply(U, m); }
    public static Functor U = constructTag(new TagInfo() { 
        tagName = "u", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });
}