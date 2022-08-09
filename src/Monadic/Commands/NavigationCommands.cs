using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic;

public class NavigationCommands
{
    public static Functor enter = (monad) => {
        if (monad.newest is null) return FailWith("No newest added element to Enter!");
        else return new MarkupMonad(monad.newest, monad.ids);
    };

    public static Functor exit = (monad) => {
        if (monad.pointer.parent is null) return FailWith("No parent to Exit to!");
        else return new MarkupMonad(monad.pointer.parent, monad.ids);
    };
}