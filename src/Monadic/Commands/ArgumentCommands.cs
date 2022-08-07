using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic;

public delegate Func<HTMLtag, MMonad> ArgumentCommand(MarkupMonad monad, string input);
public class ArgumentCommands
{
    public static ArgumentCommand @id = (monad, input) => {

        if (monad.ids.Contains(input)) return (tag) => FailWith($"Id '{input}' is already in use!");
        return (tag) => {
            tag.attributes.Add(("id", input));
            monad.ids.Add(input);
            return monad;
        };
    };

    public static ArgumentCommand text = (monad, input) => {
        return (tag) => {
            tag.children.Add(new HTMLtext(input));
            return monad;
        };
    };
}