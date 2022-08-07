
namespace SharpTemplar.Monadic;

public class CreationCommand
{
    public string tagName { get; private set; }
    public string[] directContexts { get; private set; }
    public string[] contexts { get; private set; }

    public static CreationCommand head = new CreationCommand() { 
        tagName = "head", 
        contexts = new string[]{}, 
        directContexts = new string[]{"html"}
    };
    public static CreationCommand body = new CreationCommand() { 
        tagName = "body", 
        contexts = new string[]{}, 
        directContexts = new string[]{"html"} 
    };
    public static CreationCommand div = new CreationCommand() {
        tagName = "div",
        contexts = new string[]{"body"},
        directContexts = new string[]{}
    };
    public static CreationCommand span = new CreationCommand() {
        tagName = "span",
        contexts = new string[]{"body"},
        directContexts = new string[]{}
    };
    public static CreationCommand p = new CreationCommand() {
        tagName = "p",
        contexts = new string[]{"body"},
        directContexts = new string[]{}
    };
}
