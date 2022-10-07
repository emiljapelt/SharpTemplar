namespace SharpTemplar.Monadic;

public class ExposedMonad
{
    public readonly MarkupSuccess monad;

    public ExposedMonad(MarkupMonad m) {
        if (m is MarkupSuccess ms) monad = ms;
        else throw new Exception("Test given a MarkupFailure");
    }

    public HTMLtag pointer() {
        return monad.pointer;
    }

    public HashSet<string> ids() {
        return monad.ids;
    }

    public HTMLtag newest() {
        return monad.newest;
    }

    public string Build() {
        return monad.Build();
    }
}