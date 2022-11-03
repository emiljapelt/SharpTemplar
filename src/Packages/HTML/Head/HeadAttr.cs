using static SharpTemplar.Helpers;
using static SharpTemplar.HyperText.TagContexts;

namespace SharpTemplar.HyperText;

public static partial class Head
{
    public static Attribute @charset = constructAttribute(new AttrInfo() {
        attrName = "charset",
        contexts = new InclusiveContexts(new string[]{"meta"})
    });

    public static Attribute @content = constructAttribute(new AttrInfo() {
        attrName = "content",
        contexts = new InclusiveContexts(new string[]{"meta"})
    });
}
