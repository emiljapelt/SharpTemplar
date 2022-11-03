using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Text
{
    public static Tag abbr = constructTag(new TagInfo() { 
        tagName = "abbr", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag address = constructTag(new TagInfo() { 
        tagName = "address", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag bdi = constructTag(new TagInfo() { 
        tagName = "bdi", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag bdo = constructTag(new TagInfo() { 
        tagName = "bdo", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag blockquote = constructTag(new TagInfo() { 
        tagName = "blockquote", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag q = constructTag(new TagInfo() { 
        tagName = "q", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag cite = constructTag(new TagInfo() { 
        tagName = "cite", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag code = constructTag(new TagInfo() { 
        tagName = "code", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag del = constructTag(new TagInfo() { 
        tagName = "del", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag details = constructTag(new TagInfo() { 
        tagName = "details", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag summary = constructTag(new TagInfo() { 
        tagName = "summary", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag em = constructTag(new TagInfo() { 
        tagName = "em", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag h(int level) {

        return (attrs) => (children) => (state) => {
            if (state is MarkupSuccess ms) {
                if (level < 0 || 6 < level) return FailWith("Header level must be between 1 and 6!");
                return constructTag(new TagInfo() { 
                    tagName = $"h{level}", 
                    contexts = bodyOnly, 
                    directContexts = anyContext
                })(attrs)(children)(state);
            }
            else return state;
        };
    }

    public static Tag i = constructTag(new TagInfo() { 
        tagName = "i", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag ins = constructTag(new TagInfo() { 
        tagName = "ins", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag mark = constructTag(new TagInfo() { 
        tagName = "mark", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag s = constructTag(new TagInfo() { 
        tagName = "s", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag small = constructTag(new TagInfo() { 
        tagName = "small", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag strong = constructTag(new TagInfo() { 
        tagName = "strong", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag sub = constructTag(new TagInfo() { 
        tagName = "sub", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag sup = constructTag(new TagInfo() { 
        tagName = "sup", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag time = constructTag(new TagInfo() { 
        tagName = "time", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag u = constructTag(new TagInfo() { 
        tagName = "u", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });
}