namespace SharpTemplar;

public class ExposedState
{
    public readonly MarkupSuccess state;

    public ExposedState(MarkupState m) {
        if (m is MarkupSuccess ms) state = ms;
        else throw new Exception("Test given a MarkupFailure");
    }

    public bool isInside(string tagName) {
        return state.isInside(tagName);
    }

    public XMLtag pointer() {
        return state.pointer;
    }

    public HashSet<string> ids() {
        return state.ids;
    }

    public string Build() {
        return state.Build();
    }
}