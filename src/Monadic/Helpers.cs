
namespace SharpTemplar.Monadic;

public delegate MMonad Functor(MarkupMonad m);

public class Helpers
{
    public static MMonad FailWith(string msg) 
    {
        return new MarkupFailure(msg);
    }

    public static MMonad handleFailure(MMonad monad, Functor f) {
        if (monad is MarkupMonad m) return f(m);
        else return monad;
    }
}