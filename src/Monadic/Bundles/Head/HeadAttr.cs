using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Head
{
    public static MMonad @charset(this MMonad m, string input) { return apply(@Charset(input), m); }
    public static Func<string, Functor> @Charset = constructAttribute(new AttrInfo() {
        attrName = "charset",
        contexts = new string[]{"meta"}
    });

    public static MMonad @content(this MMonad m, string input) { return apply(@Content(input), m); }
    public static Func<string, Functor> @Content = constructAttribute(new AttrInfo() {
        attrName = "content",
        contexts = new string[]{"meta"}
    });
}
