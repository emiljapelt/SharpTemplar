using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic.Bundle.Tables;

public static partial class Tables
{
    public static MMonad caption(this MMonad m) { return applyFunctor(Caption, m); }
    public static Functor Caption = constructTag(new TagInfo() { 
        tagName = "caption", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{"table"}
    });

    public static MMonad colgroup(this MMonad m) { return applyFunctor(Colgroup, m); }
    public static Functor Colgroup = constructTag(new TagInfo() { 
        tagName = "colgroup", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{"table"}
    });

    public static MMonad col(this MMonad m) { return applyFunctor(Col, m); }
    public static Functor Col = constructTag(new TagInfo() { 
        tagName = "col", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{"colgroup"}
    });

    public static MMonad table(this MMonad m) { return applyFunctor(Table, m); }
    public static Functor Table = constructTag(new TagInfo() { 
        tagName = "table", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad tbody(this MMonad m) { return applyFunctor(Tbody, m); }
    public static Functor Tbody = constructTag(new TagInfo() { 
        tagName = "tbody", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{"table"}
    });

    public static MMonad thead(this MMonad m) { return applyFunctor(Thead, m); }
    public static Functor Thead = constructTag(new TagInfo() { 
        tagName = "thead", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{"table"}
    });

    public static MMonad tfoot(this MMonad m) { return applyFunctor(Tfoot, m); }
    public static Functor Tfoot = constructTag(new TagInfo() { 
        tagName = "tfoot", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{"table"}
    });

    public static MMonad tr(this MMonad m) { return applyFunctor(Tr, m); }
    public static Functor Tr = constructTag(new TagInfo() { 
        tagName = "tr", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{"table", "thead", "tbody", "tfoot"}
    });

    public static MMonad th(this MMonad m) { return applyFunctor(Th, m); }
    public static Functor Th = constructTag(new TagInfo() { 
        tagName = "th", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{"tr"}
    });

    public static MMonad td(this MMonad m) { return applyFunctor(Td, m); }
    public static Functor Td = constructTag(new TagInfo() { 
        tagName = "td", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{"tr"}
    });
}