using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Media
{
    public static MarkupMonad audio(this MarkupMonad m) { return apply(Audio, m); }
    public static Functor Audio = constructTag(new TagInfo() { 
        tagName = "audio", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad video(this MarkupMonad m) { return apply(Video, m); }
    public static Functor Video = constructTag(new TagInfo() { 
        tagName = "video", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static MarkupMonad source(this MarkupMonad m, string type, string src) { return apply(Source(type, src), m); }
    public static Func<string, string, Functor> Source = (string type, string src) => (monad) => {
        var res =  constructTag(new TagInfo() { 
            tagName = "source", 
            contexts = bodyOnly, 
            directContexts = new string[]{"audio","video"}
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("type", type); return monad; });
        monad.newestOrCurrent((tag) => { tag.AddAttribute("src", src); return monad; });
        return res;
    };

    public static MarkupMonad img(this MarkupMonad m, string src) { return apply(Img(src, ""), m); }
    public static MarkupMonad img(this MarkupMonad m, string src, string alt) { return apply(Img(src, alt), m); }
    public static Func<string, string, Functor> Img = (string src, string alt) => (monad) => {
        var res = constructTag(new TagInfo() { 
            tagName = "img", 
            contexts = bodyOnly, 
            directContexts = anyContext
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("src", src); return monad; });
        monad.newestOrCurrent((tag) => { tag.AddAttribute("alt", alt); return monad; });
        return res;
    };
}