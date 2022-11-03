
namespace SharpTemplar.HyperText;

public static partial class Base
{
    public static MarkupState HTML(params Element[] cs) {
        MarkupState m = new MarkupSuccess(new XMLtag("html"), new HashSet<string>());
        foreach(var c in cs) {
            if (m is MarkupFailure) return m;
            m = c(m);
        }
        return m;
    }

    public static Element text(string input){ 
        return (state) => {
            if (state is MarkupSuccess m) {
                m.pointer.AddChild(new XMLtext(input));
                return m;
            }
            else return state;
        };
    }
}

internal class TagContexts
{
    internal static readonly string[] anyContext = new string[]{};
    internal static readonly string[] bodyOnly = new string[]{"body"};
    internal static readonly string[] headOnly = new string[]{"head"};
    internal static readonly string[] formOnly = new string[]{"form"};
    internal static readonly string[] tableOnly = new string[]{"table"};
}