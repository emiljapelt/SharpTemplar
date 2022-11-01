using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Lists
{
    public static Tag dl = constructTag(new TagInfo() { 
        tagName = "dl", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag dd = constructTag(new TagInfo() { 
        tagName = "dd", 
        contexts = new string[]{"dl"}, 
        directContexts = anyContext
    });

    public static Tag dt = constructTag(new TagInfo() { 
        tagName = "dt", 
        contexts = new string[]{"dl"}, 
        directContexts = anyContext
    });

    public static Tag ol = constructTag(new TagInfo() { 
        tagName = "ol", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag ul = constructTag(new TagInfo() { 
        tagName = "ul", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag li = constructTag(new TagInfo() { 
        tagName = "li", 
        contexts = new string[]{"ul", "ol"}, 
        directContexts = anyContext
    });
}