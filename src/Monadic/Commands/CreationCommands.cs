using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic;

public class CreationCommand
{
    public string tagName { get; private set; }
    public string[] directContexts { get; private set; }
    public string[] contexts { get; private set; }

    public static Functor head = construct(new CreationCommand() { 
        tagName = "head", 
        contexts = new string[]{}, 
        directContexts = new string[]{"html"}
    });
    public static Functor body = construct(new CreationCommand() { 
        tagName = "body", 
        contexts = new string[]{}, 
        directContexts = new string[]{"html"} 
    });
    public static Functor div = construct(new CreationCommand() {
        tagName = "div",
        contexts = new string[]{"body"},
        directContexts = new string[]{}
    });
    public static Functor span = construct(new CreationCommand() {
        tagName = "span",
        contexts = new string[]{"body"},
        directContexts = new string[]{}
    });
    public static Functor p = construct(new CreationCommand() {
        tagName = "p",
        contexts = new string[]{"body"},
        directContexts = new string[]{}
    });


    private static Functor construct(CreationCommand cmd)
    {
        return (monad) => {
            if (monad is MarkupMonad m) {
                var dc = false;
                var c = false;

                if (cmd.directContexts.Length == 0) dc = true;
                foreach(string directContext in cmd.directContexts)
                    if(m.pointer.tagName == directContext) dc = true;
                
                if (cmd.contexts.Length == 0) c = true;
                foreach(string context in cmd.contexts) 
                    if (m.isInside(context)) c = true;
                
                if (dc && c) { m.addHTMLtag(cmd.tagName); return m; }
                return FailWith($"'{cmd.tagName}': Context failure!");
            }
            else return monad;
        };
    }
}
