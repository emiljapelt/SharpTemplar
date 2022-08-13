using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Base
{
    public static MarkupMonad Markup()
    { 
        return new MarkupMonad(new HTMLtag("html"), new HashSet<string>()); 
    }

    public static Functor nothing = (monad) => monad;

    public static MMonad text(this MMonad m, string input) { return applyFunctor(Text(input), m); }
    public static Functor Text(string input) {
        return (monad) => {
            return monad.newestOrCurrent((tag) => {
                tag.children.Add(new HTMLtext(input));
                return monad;
            });
        };
    }

    public static MMonad Enter(this MMonad m) { return applyFunctor(enter, m); }
    public static Functor enter = (monad) => {
        if (monad.newest is null) return FailWith("No newest added element to Enter!");
        else return new MarkupMonad(monad.newest, monad.ids);
    };

    public static MMonad Exit(this MMonad m) { return applyFunctor(exit, m); }
    public static Functor exit = (monad) => {
        if (monad.pointer.parent is null) return FailWith("No parent to Exit to!");
        else return new MarkupMonad(monad.pointer.parent, monad.ids);
    };

    public static MMonad If(this MMonad m, bool b, Functor e, Functor o) { return applyFunctor(Cond(b, e, o), m); }
    public static MMonad If(this MMonad m, bool b, Functor e) { return applyFunctor(Cond(b, e, nothing), m); }
    public static Func<bool, Functor, Functor, Functor> Cond = (condition, either, or) => {
        if (condition) return either;
        else return or;
    };

    public static MMonad Range(this MMonad m, int count, Func<int, Functor> f) { return applyFunctor(Loop(0, count, f), m); }
    public static MMonad Range(this MMonad m, int start, int count, Func<int, Functor> f) { return applyFunctor(Loop(start, count, f), m); }
    public static MMonad Range(this MMonad m, int count, Functor f) { return applyFunctor(Loop(0, count, (i) => f), m); }
    public static MMonad Range(this MMonad m, int start, int count, Functor f) { return applyFunctor(Loop(start, count, (i) => f), m); }
    public static Func<int, int, Func<int, Functor>, Functor> Loop = (start, count, f) => (monad) => {
        for(int i = start; i < start + count; i++) {
            f(i)(monad);
        }
        return monad;
    };

    public static MMonad OnList<T>(this MMonad m, IEnumerable<T> l, Func<T, Functor> f) { return applyFunctor(LoopOver(l, f), m); }
    public static Functor LoopOver<T>(IEnumerable<T> list, Func<T, Functor> f) => (monad) => {
        foreach(var e in list) {
            f(e)(monad);
        }
        return monad;
    };
}