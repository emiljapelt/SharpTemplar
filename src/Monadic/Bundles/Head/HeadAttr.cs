using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Head
{
    public static Attribute @charset = constructAttribute(new AttrInfo() {
        attrName = "charset",
        contexts = new string[]{"meta"}
    });

    public static Attribute @content = constructAttribute(new AttrInfo() {
        attrName = "content",
        contexts = new string[]{"meta"}
    });
}
