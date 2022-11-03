using static SharpTemplar.Helpers;
using static SharpTemplar.HyperText.TagContexts;

namespace SharpTemplar.HyperText;

public static partial class Base
{
    public static Tag head = constructTag(new TagInfo() { 
        tagName = "head", 
        contexts = anyContext, 
        directContexts = new string[]{"html"}
    });

    public static Tag body = constructTag(new TagInfo() { 
        tagName = "body", 
        contexts = anyContext, 
        directContexts = new string[]{"html"}
    });

    public static Tag anchor = constructTag(new TagInfo() { 
        tagName = "a", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag p = constructTag(new TagInfo() { 
        tagName = "p", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Element br = constructTag(new TagInfo() { 
        tagName = "br", 
        contexts = bodyOnly, 
        directContexts = anyContext
    })()();
    

    public static Tag button = constructTag(new TagInfo() { 
        tagName = "button", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag div = constructTag(new TagInfo() { 
        tagName = "div", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag span = constructTag(new TagInfo() { 
        tagName = "span", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag main = constructTag(new TagInfo() { 
        tagName = "main", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag header = constructTag(new TagInfo() { 
        tagName = "header", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag footer = constructTag(new TagInfo() { 
        tagName = "footer", 
        contexts = bodyOnly,
        directContexts = anyContext
    });

    public static Tag script = constructTag(new TagInfo() { 
        tagName = "script", 
        contexts = anyContext, 
        directContexts = anyContext
    });

    public static Tag section = constructTag(new TagInfo() { 
        tagName = "section", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });
}