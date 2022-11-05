using static SharpTemplar.Helpers;
using static SharpTemplar.HyperText.TagContexts;

namespace SharpTemplar.HyperText;

public static partial class Forms
{
    public static Tag form(string method, string action) {
        return (attrs) => (children) => (state) => {
            if (state is MarkupSuccess ms) {
                var new_attrs = attrs.Append(constructAttribute("method", method)).Append(constructAttribute("action", action)).ToArray();
                var res = constructTag(new TagInfo() { 
                    tagName = "form", 
                    contexts = bodyOnly, 
                    directContexts = anyContext
                })(new_attrs)(children)(state);
                return res;
            }
            else return state;
        };
    }

    public static Tag input(string type) {
        return (attrs) => (children) => (state) => {
            if (state is MarkupSuccess ms) {
                var new_attrs = attrs.Append(constructAttribute("type", type)).ToArray();
                var res = constructTag(new TagInfo() {
                    tagName = "input",
                    contexts = formOnly,
                    directContexts = anyContext
                })(new_attrs)(children)(state);
                return res;
            }
            else return state;
        };
    }

    public static Tag label(string fo) {
        return (attrs) => (children) => (state) => {
            if (state is MarkupSuccess ms) {
                var new_attrs = attrs.Append(constructAttribute("for", fo)).ToArray();
                var res = constructTag(new TagInfo() {
                    tagName = "label",
                    contexts = formOnly,
                    directContexts = anyContext
                })(new_attrs)(children)(state);
                return res;
            }
            else return state;
        };
    }

    public static Tag textarea() { return textarea("1", "1"); }
    public static Tag textarea(string rows, string cols) {
        return (attrs) => (children) => (state) => {
            if (state is MarkupSuccess ms) {
                var new_attrs = attrs.Append(constructAttribute("rows", rows)).Append(constructAttribute("cols", cols)).ToArray();
                var res = constructTag(new TagInfo() {
                    tagName = "textarea",
                    contexts = formOnly,
                    directContexts = anyContext
                })(new_attrs)(children)(state);
                return res;
            }
            else return state;
        };
    }

    public static Tag select = constructTag(new TagInfo() {
        tagName = "select",
        contexts = formOnly,
        directContexts = anyContext
    });

    public static Tag option(string value) {
        return (attrs) => (children) => (state) => {
            if (state is MarkupSuccess ms) {
                var new_attrs = attrs.Append(constructAttribute("value", value)).ToArray();
                var res = constructTag(new TagInfo() {
                    tagName = "option",
                    contexts = formOnly,
                    directContexts = new string[]{"select","optgroup","datalist"}
                })(new_attrs)(children)(state);
                return res;
            }
            else return state;
        };
    }

    public static Tag optgroup(string label) {
        return (attrs) => (children) => (state) => {
            if (state is MarkupSuccess ms) {
                var new_attrs = attrs.Append(constructAttribute("label", label)).ToArray();
                var res = constructTag(new TagInfo() {
                    tagName = "optgroup",
                    contexts = formOnly,
                    directContexts = new string[]{"select"}
                })(new_attrs)(children)(state);
                return res;
            }
            else return state;
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