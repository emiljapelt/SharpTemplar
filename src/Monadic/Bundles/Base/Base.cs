using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Base
{
    public static MarkupState Markup(params Element[] cs) {
        MarkupState m = new MarkupSuccess(new HTMLtag("html"), new HashSet<string>());
        foreach(var c in cs) {
            if (m is MarkupFailure) return m;
            m = c(m);
        }
        return m;
    }

    public static Element nothing = (state) => state;

    public static Element text(string input){ 
        return (state) => {
            if (state is MarkupSuccess m) {
                m.pointer.AddChild(new HTMLtext(input));
                return m;
            }
            else return state;
        };
    }

    public static Element If(bool b, Element e) { return If(b, e, nothing); }
    public static Element If(bool condition, Element either, Element or) {
        if (condition) return either;
        else return or;
    }

    public static Element Attempt(Func<Element> main) { return Attempt(main, () => nothing); }
    public static Element Attempt(Func<Element> main, Func<Element> alternative) {
        return (state) => {
            if (state is MarkupSuccess ms) {
                var html_backup = ms.pointer.RefingClone();
                var id_backup = new HashSet<string>(ms.ids);
                try {
                    return main()(ms);
                }
                catch (Exception) {
                    ms = new MarkupSuccess(html_backup, id_backup);
                    return alternative()(ms);
                }
            }
            else return state;
        };
    }

    public static Element Range(int count, Element element) { return Range(0, count, (i) => element); }
    public static Element Range(int start, int count, Element element) { return Range(start, count, (i) => element); }
    public static Element Range(int count, Func<int, Element> element) { return Range(0, count, element); }
    public static Element Range(int start, int count, Func<int, Element> elemet){
        return (state) => {
            for(int i = start; i < start + count; i++) {
                elemet(i)(state);
            }
            return state;
        };
    }

    public static Element OnList<T>(IEnumerable<T> list, Func<T, Element> element) {
        return (state) => {
            foreach(var e in list) {
                element(e)(state);
            }
            return state;
        };
    }
}