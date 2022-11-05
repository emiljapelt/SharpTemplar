using static SharpTemplar.Helpers;
using static SharpTemplar.HyperText.TagContexts;

namespace SharpTemplar.HyperText;

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
        return (attrs) => (children) => (state) => {
            if (state is MarkupSuccess ms) {
                var new_attrs = attrs.Append(constructAttribute("type", type)).Append(constructAttribute("src", src)).ToArray();
                var res =  constructTag(new TagInfo() { 
                    tagName = "source", 
                    contexts = bodyOnly, 
                    directContexts = new string[]{"audio","video"}
                })(new_attrs)(children)(state);
                return res;
            }
            else return state;
        };
    }

    public static Tag img(string src) { return img(src, ""); }
    public static Tag img(string src, string alt) {

        return (attrs) => (children) => (state) => {
            if (state is MarkupSuccess ms) {
                var new_attrs = attrs.Append(constructAttribute("src", src)).Append(constructAttribute("alt", alt)).ToArray();
                var res = constructTag(new TagInfo() { 
                    tagName = "img", 
                    contexts = bodyOnly, 
                    directContexts = anyContext
                })(attrs)(children)(state);
                return res;
            } 
            else return state;
        };
    }
}