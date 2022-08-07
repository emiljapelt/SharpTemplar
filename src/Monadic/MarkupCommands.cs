using static SharpTemplar.Monadic.Helpers;

namespace SharpTemplar.Monadic;

public enum NavigationCommand
{
    enter,
    exit,
}

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

public delegate Func<HTMLtag, MMonad> ArgumentCommand(MarkupMonad monad, string input);
public class ArgumentCommands
{
    public static ArgumentCommand @id = (monad, input) => {

        if (monad.ids.Contains(input)) return (tag) => FailWith($"Id '{input}' is already in use!");
        return (tag) => {
            tag.attributes.Add(("id", input));
            monad.ids.Add(input);
            return monad;
        };
    };

    public static ArgumentCommand text = (monad, input) => {
        return (tag) => {
            tag.children.Add(new HTMLtext(input));
            return monad;
        };
    };
}

public delegate Func<HTMLtag, MMonad> ParamsCommand(MarkupMonad monad, params string[] inputs);
public class ParamsCommands
{
    public static ParamsCommand @class = (monad, inputs) => {
        return (tag) => {
            tag.attributes.Add(("class", string.Join(" ", inputs)));
            return monad;
        };
    };
}
