using static SharpTemplar.Monadic.Helpers;
using static SharpTemplar.Monadic.TagContexts;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Base
{
    public static MMonad @id(this MMonad m, string input) { return applyFunctor(@Id(input), m); }
    public static Func<string, Functor> @Id = (input) => (monad) => {
        if (monad.ids.Contains(input)) return FailWith($"Id '{input}' is already in use!");
        monad.ids.Add(input);
        var res = constructAttribute(new AttrInfo() {
            attrName = "id",
            contexts = anyContext
        })(input)(monad);
        return res;
    };


    public static MMonad @class(this MMonad m, params string[] input) { return applyFunctor(@Class(string.Join(" ", input)), m); }
    public static Func<string, Functor> @Class = constructAttribute(new AttrInfo() {
        attrName = "class",
        contexts = anyContext
    });


    public static MMonad @defer(this MMonad m, bool b) { return applyFunctor(@Defer(b.ToString().ToLower()), m); }
    public static MMonad @defer(this MMonad m) { return applyFunctor(@Defer("true"), m); }
    public static Func<string, Functor> @Defer = (input) => (monad) => {
        var res = constructAttribute(new AttrInfo() {
            attrName = "defer",
            contexts = new string[]{"script"}
        })(input)(monad);
        return res;
    };

    public static MMonad @href(this MMonad m, string input) { return applyFunctor(@Href(input), m); }
    public static Func<string, Functor> @Href = (input) => (monad) => {
        var res = constructAttribute(new AttrInfo() {
            attrName = "href",
            contexts = new string[]{"a","area","base","link"}
        })(input)(monad);
        return res;
    };

    public static MMonad @name(this MMonad m, string input) { return applyFunctor(@Name(input), m); }
    public static Func<string, Functor> @Name = (string name) => (monad) => {
    return constructAttribute(new AttrInfo() {
        attrName = "name",
        contexts = new string[]{"button", "form", "input", "meta", "select", "textarea"}
    })(name)(monad);
    };
}
