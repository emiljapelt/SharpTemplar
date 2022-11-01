using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Forms
{
    public static Tag form(string method, string action) {
        return (attrs) => (children) => (monad) => {
            if (monad is MarkupSuccess ms) {
                var res = constructTag(new TagInfo() { 
                    tagName = "form", 
                    contexts = bodyOnly, 
                    directContexts = anyContext
                })(attrs)(children)(monad);
                
                ms.pointer.AddAttribute("method", method);
                ms.pointer.AddAttribute("action", action);
                return res;
            }
            else return monad;
        };
    }

    public static Tag input(string type) {
        return (attrs) => (children) => (monad) => {
            if (monad is MarkupSuccess ms) {
                var res = constructTag(new TagInfo() {
                    tagName = "input",
                    contexts = formOnly,
                    directContexts = anyContext
                })(attrs)(children)(monad);
                ms.pointer.AddAttribute("type", type);
                return res;
            }
            else return monad;
        };
    }

    public static Tag label(string fo) {
        return (attrs) => (children) => (monad) => {
            if (monad is MarkupSuccess ms) {
                var res = constructTag(new TagInfo() {
                    tagName = "label",
                    contexts = formOnly,
                    directContexts = anyContext
                })(attrs)(children)(monad);
                ms.pointer.AddAttribute("for", fo);
                return res;
            }
            else return monad;
        };
    }

    public static Tag textarea() { return textarea("1", "1"); }
    public static Tag textarea(string rows, string cols) {
        return (attrs) => (children) => (monad) => {
            if (monad is MarkupSuccess ms) {
                var res = constructTag(new TagInfo() {
                    tagName = "textarea",
                    contexts = formOnly,
                    directContexts = anyContext
                })(attrs)(children)(monad);
                ms.pointer.AddAttribute("rows", rows);
                ms.pointer.AddAttribute("cols", cols);
                return res;
            }
            else return monad;
        };
    }

    public static Tag select = constructTag(new TagInfo() {
        tagName = "select",
        contexts = formOnly,
        directContexts = anyContext
    });

    public static Tag option(string value) {
        return (attrs) => (children) => (monad) => {
            if (monad is MarkupSuccess ms) {
                var res = constructTag(new TagInfo() {
                    tagName = "option",
                    contexts = formOnly,
                    directContexts = new string[]{"select","optgroup","datalist"}
                })(attrs)(children)(monad);
                ms.pointer.AddAttribute("value", value);
                return res;
            }
            else return monad;
        };
    }

    public static Tag optgroup(string label) {
        return (attrs) => (children) => (monad) => {
            if (monad is MarkupSuccess ms) {
                var res = constructTag(new TagInfo() {
                    tagName = "optgroup",
                    contexts = formOnly,
                    directContexts = new string[]{"select"}
                })(attrs)(children)(monad);
                ms.pointer.AddAttribute("label", label);
                return res;
            }
            else return monad;
        };
    }

    public static Tag dataList = constructTag(new TagInfo() {
        tagName = "datalist",
        contexts = formOnly,
        directContexts = anyContext
    });

    public static Tag fieldset = constructTag(new TagInfo() {
        tagName = "fieldset",
        contexts = formOnly,
        directContexts = anyContext
    });

    public static Tag legend = constructTag(new TagInfo() {
        tagName = "legend",
        contexts = formOnly,
        directContexts = new string[]{"fieldset"}
    });
}