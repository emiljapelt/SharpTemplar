using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Media
{
    public static MMonad audio(this MMonad m) { return applyFunctor(Audio, m); }
    public static Functor Audio = constructTag(new TagInfo() { 
        tagName = "audio", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad video(this MMonad m) { return applyFunctor(Video, m); }
    public static Functor Video = constructTag(new TagInfo() { 
        tagName = "video", 
        contexts = new string[]{"body"}, 
        directContexts = new string[]{}
    });

    public static MMonad source(this MMonad m, string type, string src) { return applyFunctor(Source(type, src), m); }
    public static Func<string, string, Functor> Source = (string type, string src) => (monad) => {
        var res =  constructTag(new TagInfo() { 
            tagName = "source", 
            contexts = new string[]{"body"}, 
            directContexts = new string[]{"audio","video"}
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("type", type); return monad; });
        monad.newestOrCurrent((tag) => { tag.AddAttribute("src", src); return monad; });
        return res;
    };

    public static MMonad img(this MMonad m, string src) { return applyFunctor(Img(src, ""), m); }
    public static MMonad img(this MMonad m, string src, string alt) { return applyFunctor(Img(src, alt), m); }
    public static Func<string, string, Functor> Img = (string src, string alt) => (monad) => {
        var res = constructTag(new TagInfo() { 
            tagName = "img", 
            contexts = new string[]{"body"}, 
            directContexts = new string[]{}
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("src", src); return monad; });
        monad.newestOrCurrent((tag) => { tag.AddAttribute("alt", alt); return monad; });
        return res;
    };
}