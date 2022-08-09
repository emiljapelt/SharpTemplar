
namespace SharpTemplar.Monadic;

public delegate MMonad Functor(MarkupMonad m);

public class Helpers
{
    public static MMonad FailWith(string msg) 
    {
        return new MarkupFailure(msg);
    }

    public static MMonad applyFunctor(Functor f, MMonad target) {
        if (target is MarkupMonad m) return f(m);
        else return target;
    }
}