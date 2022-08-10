using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Base
{
    public static MMonad @id(this MMonad m, string input) { return applyFunctor(@Id(input), m); }
    public static Functor @Id(string input) {
        return (monad) => {
            if (monad.ids.Contains(input)) return FailWith($"Id '{input}' is already in use!");
            monad.ids.Add(input);
            return monad.newestOrCurrent((tag) => {
                tag.AddAttribute("id", input);
                return monad;
            });
        };
    }

    public static MMonad @class(this MMonad m, params string[] inputs) { return applyFunctor(@Class(inputs), m); }
    public static Functor @Class(params string[] inputs) {
        return (monad) => {
            return monad.newestOrCurrent((tag) => {
                tag.AddAttribute("class", string.Join(" ", inputs));
                return monad;
            });
        };
    }
}
