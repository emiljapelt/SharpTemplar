
namespace SharpTemplar.Monadic;

public delegate MMonad Functor(MarkupMonad m);

public class TagInfo
{
    public string tagName { get; set; }
    public string[] directContexts { get; set; }
    public string[] contexts { get; set; }
}

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

    public static Functor constructTag(TagInfo info)
    {
        return (monad) => {
            if (monad is MarkupMonad m) {
                var dc = false;
                var c = false;

                if (info.directContexts.Length == 0) dc = true;
                foreach(string directContext in info.directContexts)
                    if(m.pointer.tagName == directContext) dc = true;
                
                if (info.contexts.Length == 0) c = true;
                foreach(string context in info.contexts) 
                    if (m.isInside(context)) c = true;
                
                if (dc && c) { m.addHTMLtag(info.tagName); return m; }
                return FailWith($"'{info.tagName}': Context failure!");
            }
            else return monad;
        };
    }
}