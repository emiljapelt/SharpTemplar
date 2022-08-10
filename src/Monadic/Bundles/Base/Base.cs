using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Base
{
    public static MarkupMonad Markup()
    { 
        return new MarkupMonad(new HTMLtag("html"), new HashSet<string>()); 
    }

    public static MMonad text(this MMonad m, string input) { return applyFunctor(Text(input), m); }
    public static Functor Text(string input) {
        return (monad) => {
            return monad.newestOrCurrent((tag) => {
                tag.children.Add(new HTMLtext(input));
                return monad;
            });
        };
    }

    public static MMonad enter(this MMonad m) { return applyFunctor(Enter, m); }
    public static Functor Enter = (monad) => {
        if (monad.newest is null) return FailWith("No newest added element to Enter!");
        else return new MarkupMonad(monad.newest, monad.ids);
    };

    public static MMonad exit(this MMonad m) { return applyFunctor(Exit, m); }
    public static Functor Exit = (monad) => {
        if (monad.pointer.parent is null) return FailWith("No parent to Exit to!");
        else return new MarkupMonad(monad.pointer.parent, monad.ids);
    };
}