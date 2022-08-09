using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic;

public class ArgumentCommands
{
    public static Functor text(string input) {
        return (monad) => {
            return monad.newestOrCurrent((tag) => {
                tag.children.Add(new HTMLtext(input));
                return monad;
            });
        };
    }

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

    public static Functor @class(params string[] inputs) {
        return (monad) => {
            return monad.newestOrCurrent((tag) => {
                tag.AddAttribute("class", string.Join(" ", inputs));
                return monad;
            });
        };
    }
}