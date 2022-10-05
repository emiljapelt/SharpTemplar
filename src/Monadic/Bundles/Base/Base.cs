using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic.Bundle;

public static partial class Base
{
    public static MarkupSuccess Markup()
    { 
        return new MarkupSuccess(new HTMLtag("html"), new HashSet<string>()); 
    }

    public static Functor nothing = (monad) => monad;

    public static MarkupMonad text(this MarkupMonad m, string input) { return apply(Text(input), m); }
    public static Functor Text(string input) {
        return (monad) => {
            return monad.newestOrCurrent((tag) => {
                tag.children.Add(new HTMLtext(input));
                return monad;
            });
        };
    }

    public static MarkupMonad Anchor(this MarkupMonad m, Functor f) { return apply(AnchorFunctor(f), m); }
    public static Functor AnchorFunctor(Functor f) {
        return (monad) => {
            apply(f, monad);
            return monad;
        };
    }

    public static MarkupMonad Enter(this MarkupMonad m) { return apply(enter, m); }
    public static Functor enter = (monad) => {
        if (monad.newest is null) return FailWith("No newest added element to Enter!");
        else return new MarkupSuccess(monad.newest, monad.ids);
    };

    public static MarkupMonad Exit(this MarkupMonad m) { return apply(exit, m); }
    public static Functor exit = (monad) => {
        if (monad.pointer.parent is null) return FailWith("No parent to Exit to!");
        else return new MarkupSuccess(monad.pointer.parent, monad.ids);
    };

    public static MarkupMonad If(this MarkupMonad m, bool b, Functor e, Functor o) { return apply(Cond(b, e, o), m); }
    public static MarkupMonad If(this MarkupMonad m, bool b, Functor e) { return apply(Cond(b, e, nothing), m); }
    public static Func<bool, Functor, Functor, Functor> Cond = (condition, either, or) => {
        if (condition) return either;
        else return or;
    };

    public static MarkupMonad Attempt(this MarkupMonad m, Functor main, Functor alternative) { return apply(TryCatch(main, alternative), m); }
    public static MarkupMonad Attempt(this MarkupMonad m, Functor main) { return apply(TryCatch(main, nothing), m); }
    public static Func<Functor, Functor, Functor> TryCatch = (main, alternative) => (monad) => {
        var backup = new List<HTMLElement>(monad.pointer.children);
        try {
            return apply(main, monad);
        }
        catch (Exception) {
            monad.pointer.children = backup;
            return apply(alternative, monad);
        }
    };

    public static MarkupMonad Range(this MarkupMonad m, int count, Func<int, Functor> f) { return apply(Loop(0, count, f), m); }
    public static MarkupMonad Range(this MarkupMonad m, int start, int count, Func<int, Functor> f) { return apply(Loop(start, count, f), m); }
    public static MarkupMonad Range(this MarkupMonad m, int count, Functor f) { return apply(Loop(0, count, (i) => f), m); }
    public static MarkupMonad Range(this MarkupMonad m, int start, int count, Functor f) { return apply(Loop(start, count, (i) => f), m); }
    public static Func<int, int, Func<int, Functor>, Functor> Loop = (start, count, f) => (monad) => {
        for(int i = start; i < start + count; i++) {
            f(i)(monad);
        }
        return monad;
    };

    public static MarkupMonad OnList<T>(this MarkupMonad m, IEnumerable<T> l, Func<T, Functor> f) { return apply(LoopOver(l, f), m); }
    public static Functor LoopOver<T>(IEnumerable<T> list, Func<T, Functor> f) => (monad) => {
        foreach(var e in list) {
            f(e)(monad);
        }
        return monad;
    };
}