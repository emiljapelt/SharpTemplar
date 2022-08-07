namespace SharpTemplar.Monadic;

public delegate Func<HTMLtag, MMonad> ParamsCommand(MarkupMonad monad, params string[] inputs);
public class ParamsCommands
{
    public static ParamsCommand @class = (monad, inputs) => {
        return (tag) => {
            tag.attributes.Add(("class", string.Join(" ", inputs)));
            return monad;
        };
    };
}