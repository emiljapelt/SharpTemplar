using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Forms
{
    public static MarkupMonad form(this MarkupMonad m, string method, string action) { return apply(Form(method, action), m); }
    public static Func<string, string, Functor> Form = (string method, string action) => (monad) => {
        var res = constructTag(new TagInfo() { 
            tagName = "form", 
            contexts = bodyOnly, 
            directContexts = anyContext
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("method", method); return monad; });
        monad.newestOrCurrent((tag) => { tag.AddAttribute("action", action); return monad; });
        return res;
    };

    public static MarkupMonad input(this MarkupMonad m, string type) { return apply(Input(type), m); }
    public static Func<string, Functor> Input = (string type) => (monad) => {
        var res = constructTag(new TagInfo() {
            tagName = "input",
            contexts = formOnly,
            directContexts = anyContext
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("type", type); return monad; });
        return res;
    };

    public static MarkupMonad label(this MarkupMonad m, string fo) { return apply(Label(fo), m); }
    public static Func<string, Functor> Label = (string fo) => (monad) => {
        var res = constructTag(new TagInfo() {
            tagName = "label",
            contexts = formOnly,
            directContexts = anyContext
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("for", fo); return monad; });
        return res;
    };

    public static MarkupMonad textarea(this MarkupMonad m, string rows, string cols) { return apply(TextArea(rows, cols), m); }
    public static MarkupMonad textarea(this MarkupMonad m) { return apply(TextArea("1", "1"), m); }
    public static Func<string, string, Functor> TextArea = (string rows, string cols) => (monad) => {
        var res = constructTag(new TagInfo() {
            tagName = "textarea",
            contexts = formOnly,
            directContexts = anyContext
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("rows", rows); return monad; });
        monad.newestOrCurrent((tag) => { tag.AddAttribute("cols", cols); return monad; });
        return res;
    };

    public static MarkupMonad select(this MarkupMonad m) { return apply(Select, m); }
    public static Functor Select = constructTag(new TagInfo() {
        tagName = "select",
        contexts = formOnly,
        directContexts = anyContext
    });

    public static MarkupMonad option(this MarkupMonad m, string value) { return apply(Option(value), m); }
    public static Func<string, Functor> Option = (string value) => (monad) => {
        var res = constructTag(new TagInfo() {
            tagName = "option",
            contexts = formOnly,
            directContexts = new string[]{"select","optgroup","datalist"}
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("value", value); return monad; });
        return res;
    };

    public static MarkupMonad optgroup(this MarkupMonad m, string label) { return apply(OptGroup(label), m); }
    public static Func<string, Functor> OptGroup = (string label) => (monad) => {
        var res = constructTag(new TagInfo() {
            tagName = "optgroup",
            contexts = formOnly,
            directContexts = new string[]{"select"}
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("label", label); return monad; });
        return res;
    };

    public static MarkupMonad datalist(this MarkupMonad m) { return apply(DataList, m); }
    public static Functor DataList = constructTag(new TagInfo() {
        tagName = "datalist",
        contexts = formOnly,
        directContexts = anyContext
    });

    public static MarkupMonad fieldset(this MarkupMonad m) { return apply(FieldSet, m); }
    public static Functor FieldSet = constructTag(new TagInfo() {
        tagName = "fieldset",
        contexts = formOnly,
        directContexts = anyContext
    });

    public static MarkupMonad legend(this MarkupMonad m) { return apply(Legend, m); }
    public static Functor Legend = constructTag(new TagInfo() {
        tagName = "legend",
        contexts = formOnly,
        directContexts = new string[]{"fieldset"}
    });
}