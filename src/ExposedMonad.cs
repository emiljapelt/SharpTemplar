namespace SharpTemplar.Monadic;

public class ExposedMonad
{
    public readonly MarkupSuccess monad;

    public ExposedMonad(MarkupMonad m) {
        if (m is MarkupSuccess ms) monad = ms;
        else throw new Exception("Test given a MarkupFailure");
    }

    public bool isInside(string tagName) {
        return monad.isInside(tagName);
    }

    public MarkupMonad newestOrCurrent(Func<HTMLtag, MarkupMonad> f) {
        return monad.newestOrCurrent(f);
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