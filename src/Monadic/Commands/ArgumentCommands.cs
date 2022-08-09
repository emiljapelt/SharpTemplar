using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic;

public static class ArgumentCommands
{
    public static MMonad Text(this MMonad m, string input) { return applyFunctor(text(input), m); }
    public static Functor text(string input) {
        return (monad) => {
            return monad.newestOrCurrent((tag) => {
                tag.children.Add(new HTMLtext(input));
                return monad;
            });
        };
    }

    public static MMonad @Id(this MMonad m, string input) { return applyFunctor(@id(input), m); }
    public static Functor @id(string input) {
        return (monad) => {
            if (monad.ids.Contains(input)) return FailWith($"Id '{input}' is already in use!");
            monad.ids.Add(input);
            return monad.newestOrCurrent((tag) => {
                tag.AddAttribute("id", input);
                return monad;
            });
        };
    }

    public static MMonad @Class(this MMonad m, params string[] inputs) { return applyFunctor(@class(inputs), m); }
    public static Functor @class(params string[] inputs) {
        return (monad) => {
            return monad.newestOrCurrent((tag) => {
                tag.AddAttribute("class", string.Join(" ", inputs));
                return monad;
            });
        };
    }
}