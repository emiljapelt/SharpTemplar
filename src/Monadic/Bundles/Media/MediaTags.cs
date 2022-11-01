using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Media
{
    public static Tag audio = constructTag(new TagInfo() { 
        tagName = "audio", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag video = constructTag(new TagInfo() { 
        tagName = "video", 
        contexts = bodyOnly, 
        directContexts = anyContext
    });

    public static Tag source(string type, string src) {
        return (attrs) => (children) => (monad) => {
            if (monad is MarkupSuccess ms) {
                var res =  constructTag(new TagInfo() { 
                    tagName = "source", 
                    contexts = bodyOnly, 
                    directContexts = new string[]{"audio","video"}
                })(attrs)(children)(monad);
                ms.pointer.AddAttribute("type", type);
                ms.pointer.AddAttribute("src", src);
                return res;
            }
            else return monad;
        };
    }

    public static Tag img(string src) { return img(src, ""); }
    public static Tag img(string src, string alt) {

        return (attrs) => (children) => (monad) => {
            if (monad is MarkupSuccess ms) {
                var res = constructTag(new TagInfo() { 
                    tagName = "img", 
                    contexts = bodyOnly, 
                    directContexts = anyContext
                })(attrs)(children)(monad);
                ms.pointer.AddAttribute("src", src);
                ms.pointer.AddAttribute("alt", alt);
                return res;
            } 
            else return monad;
        };
    }
}