using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic;

public class CreationInfo
{
    public string tagName { get; set; }
    public string[] directContexts { get; set; }
    public string[] contexts { get; set; }
}

public static class CreationCommands
{
    public static MMonad Head(this MMonad m) { return applyFunctor(head, m); }
    public static Functor head = constructTag(new CreationInfo() { 
        tagName = "head", 
        contexts = new string[]{}, 
        directContexts = new string[]{"html"}
    });

    public static MMonad Body(this MMonad m) { return applyFunctor(body, m); }
    public static Functor body = constructTag(new CreationInfo() { 
        tagName = "body", 
        contexts = new string[]{}, 
        directContexts = new string[]{"html"} 
    });

    public static MMonad Div(this MMonad m) { return applyFunctor(div, m); }
    public static Functor div = constructTag(new CreationInfo() {
        tagName = "div",
        contexts = new string[]{"body"},
        directContexts = new string[]{}
    });

    public static MMonad Span(this MMonad m) { return applyFunctor(span, m); }
    public static Functor span = constructTag(new CreationInfo() {
        tagName = "span",
        contexts = new string[]{"body"},
        directContexts = new string[]{}
    });

    public static MMonad P(this MMonad m) { return applyFunctor(p, m); }
    public static Functor p = constructTag(new CreationInfo() {
        tagName = "p",
        contexts = new string[]{"body"},
        directContexts = new string[]{}
    });


    public static Functor constructTag(CreationInfo info)
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
