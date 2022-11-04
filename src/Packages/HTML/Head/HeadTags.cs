using static SharpTemplar.Helpers;
using static SharpTemplar.HyperText.TagContexts;

namespace SharpTemplar.HyperText;

public static partial class Head
{
    public static Tag basis = constructTag(new TagInfo() { 
        tagName = "base", 
        contexts = anyContext, 
        directContexts = headOnly
    });

    public static Tag link = constructTag(new TagInfo() { 
        tagName = "link", 
        contexts = anyContext, 
        directContexts = headOnly
    });

    public static Tag meta = constructTag(new TagInfo() { 
        tagName = "meta", 
        contexts = anyContext, 
        directContexts = headOnly
    });

    public static Tag style = constructTag(new TagInfo() { 
        tagName = "style", 
        contexts = anyContext, 
        directContexts = headOnly
    });

    public static Tag title = constructTag(new TagInfo() { 
        tagName = "title", 
        contexts = anyContext, 
        directContexts = headOnly
    });
}