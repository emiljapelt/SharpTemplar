using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle.Tables;

public static partial class Tables
{
    public static MarkupMonad caption(this MarkupMonad m) { return apply(Caption, m); }
    public static Functor Caption = constructTag(new TagInfo() { 
        tagName = "caption", 
        contexts = bodyOnly, 
        directContexts = tableOnly
    });

    public static MarkupMonad colgroup(this MarkupMonad m) { return apply(Colgroup, m); }
    public static Functor Colgroup = constructTag(new TagInfo() { 
        tagName = "colgroup", 
        contexts = bodyOnly, 
        directContexts = tableOnly
    });

    public static MarkupMonad col(this MarkupMonad m) { return apply(Col, m); }
    public static Functor Col = constructTag(new TagInfo() { 
        tagName = "col", 
        contexts = bodyOnly, 
        directContexts = new string[]{"colgroup"}
    });

    public static MarkupMonad table(this MarkupMonad m) { return apply(Table, m); }
    public static Functor Table = constructTag(new TagInfo() { 
        tagName = "table", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad tbody(this MarkupMonad m) { return apply(Tbody, m); }
    public static Functor Tbody = constructTag(new TagInfo() { 
        tagName = "tbody", 
        contexts = bodyOnly, 
        directContexts = tableOnly
    });

    public static MarkupMonad thead(this MarkupMonad m) { return apply(Thead, m); }
    public static Functor Thead = constructTag(new TagInfo() { 
        tagName = "thead", 
        contexts = bodyOnly, 
        directContexts = tableOnly
    });

    public static MarkupMonad tfoot(this MarkupMonad m) { return apply(Tfoot, m); }
    public static Functor Tfoot = constructTag(new TagInfo() { 
        tagName = "tfoot", 
        contexts = bodyOnly, 
        directContexts = tableOnly
    });

    public static MarkupMonad tr(this MarkupMonad m) { return apply(Tr, m); }
    public static Functor Tr = constructTag(new TagInfo() { 
        tagName = "tr", 
        contexts = bodyOnly, 
        directContexts = new string[]{"table", "thead", "tbody", "tfoot"}
    });

    public static MarkupMonad th(this MarkupMonad m) { return apply(Th, m); }
    public static Functor Th = constructTag(new TagInfo() { 
        tagName = "th", 
        contexts = bodyOnly, 
        directContexts = new string[]{"tr"}
    });

    public static MarkupMonad td(this MarkupMonad m) { return apply(Td, m); }
    public static Functor Td = constructTag(new TagInfo() { 
        tagName = "td", 
        contexts = bodyOnly, 
        directContexts = new string[]{"tr"}
    });
}