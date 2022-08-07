
namespace SharpTemplar.Monadic;

public class Helpers
{
    public static MMonad FailWith(string msg) 
    {
        return new MarkupFailure(msg);
    }
}