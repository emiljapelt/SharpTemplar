using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle.Tables;

public static partial class Tables
{
    public static Tag caption = constructTag(new TagInfo() { 
        tagName = "caption", 
        contexts = bodyOnly, 
        directContexts = tableOnly
    });

    public static Tag colgroup = constructTag(new TagInfo() { 
        tagName = "colgroup", 
        contexts = bodyOnly, 
        directContexts = tableOnly
    });

    public static Tag col = constructTag(new TagInfo() { 
        tagName = "col", 
        contexts = bodyOnly, 
        directContexts = new string[]{"colgroup"}
    });

    public static Tag table = constructTag(new TagInfo() { 
        tagName = "table", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag tbody = constructTag(new TagInfo() { 
        tagName = "tbody", 
        contexts = bodyOnly, 
        directContexts = tableOnly
    });

    public static Tag thead = constructTag(new TagInfo() { 
        tagName = "thead", 
        contexts = bodyOnly, 
        directContexts = tableOnly
    });

    public static Tag tfoot = constructTag(new TagInfo() { 
        tagName = "tfoot", 
        contexts = bodyOnly, 
        directContexts = tableOnly
    });

    public static Tag tr = constructTag(new TagInfo() { 
        tagName = "tr", 
        contexts = bodyOnly, 
        directContexts = new string[]{"table", "thead", "tbody", "tfoot"}
    });

    public static Tag th = constructTag(new TagInfo() { 
        tagName = "th", 
        contexts = bodyOnly, 
        directContexts = new string[]{"tr"}
    });

    public static Tag td = constructTag(new TagInfo() { 
        tagName = "td", 
        contexts = bodyOnly, 
        directContexts = new string[]{"tr"}
    });
}