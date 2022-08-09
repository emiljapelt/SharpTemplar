
namespace SharpTemplar.Monadic;

public delegate MMonad Functor(MarkupMonad m);

public class Helpers
{
    public static MMonad FailWith(string msg) 
    {
        return new MarkupFailure(msg);
    }
}