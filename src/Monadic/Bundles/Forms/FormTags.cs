using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Forms
{
    public static MMonad form(this MMonad m, string method, string action) { return applyFunctor(Form(method, action), m); }
    public static Func<string, string, Functor> Form = (string method, string action) => (monad) => {
        var res = constructTag(new TagInfo() { 
            tagName = "form", 
            contexts = new string[]{"body"}, 
            directContexts = new string[]{}
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("method", method); return monad; });
        monad.newestOrCurrent((tag) => { tag.AddAttribute("action", action); return monad; });
        return res;
    };

    public static MMonad input(this MMonad m, string type) { return applyFunctor(Input(type), m); }
    public static Func<string, Functor> Input = (string type) => (monad) => {
        var res = constructTag(new TagInfo() {
            tagName = "input",
            contexts = new string[]{"form"},
            directContexts = new string[]{}
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("type", type); return monad; });
        return res;
    };

    public static MMonad label(this MMonad m, string fo) { return applyFunctor(Label(fo), m); }
    public static Func<string, Functor> Label = (string fo) => (monad) => {
        var res = constructTag(new TagInfo() {
            tagName = "label",
            contexts = new string[]{"form"},
            directContexts = new string[]{}
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("for", fo); return monad; });
        return res;
    };

    public static MMonad textarea(this MMonad m, string rows, string cols) { return applyFunctor(TextArea(rows, cols), m); }
    public static MMonad textarea(this MMonad m) { return applyFunctor(TextArea("1", "1"), m); }
    public static Func<string, string, Functor> TextArea = (string rows, string cols) => (monad) => {
        var res = constructTag(new TagInfo() {
            tagName = "textarea",
            contexts = new string[]{"form"},
            directContexts = new string[]{}
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("rows", rows); return monad; });
        monad.newestOrCurrent((tag) => { tag.AddAttribute("cols", cols); return monad; });
        return res;
    };

    public static MMonad select(this MMonad m) { return applyFunctor(Select, m); }
    public static Functor Select = constructTag(new TagInfo() {
        tagName = "select",
        contexts = new string[]{"form"},
        directContexts = new string[]{}
    });

    public static MMonad option(this MMonad m, string value) { return applyFunctor(Option(value), m); }
    public static Func<string, Functor> Option = (string value) => (monad) => {
        var res = constructTag(new TagInfo() {
            tagName = "option",
            contexts = new string[]{"form"},
            directContexts = new string[]{"select","optgroup","datalist"}
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("value", value); return monad; });
        return res;
    };

    public static MMonad optgroup(this MMonad m, string label) { return applyFunctor(OptGroup(label), m); }
    public static Func<string, Functor> OptGroup = (string label) => (monad) => {
        var res = constructTag(new TagInfo() {
            tagName = "optgroup",
            contexts = new string[]{"form"},
            directContexts = new string[]{"select"}
        })(monad);
        monad.newestOrCurrent((tag) => { tag.AddAttribute("label", label); return monad; });
        return res;
    };

    public static MMonad datalist(this MMonad m) { return applyFunctor(DataList, m); }
    public static Functor DataList = constructTag(new TagInfo() {
        tagName = "datalist",
        contexts = new string[]{"form"},
        directContexts = new string[]{}
    });

    public static MMonad fieldset(this MMonad m) { return applyFunctor(FieldSet, m); }
    public static Functor FieldSet = constructTag(new TagInfo() {
        tagName = "fieldset",
        contexts = new string[]{"form"},
        directContexts = new string[]{}
    });

    public static MMonad legend(this MMonad m) { return applyFunctor(Legend, m); }
    public static Functor Legend = constructTag(new TagInfo() {
        tagName = "legend",
        contexts = new string[]{"form"},
        directContexts = new string[]{"fieldset"}
    });
}