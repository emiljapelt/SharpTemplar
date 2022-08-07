using static SharpTemplar.Monadic.MarkupMonad;
using static SharpTemplar.Monadic.CreationCommand;
using static SharpTemplar.Monadic.NavigationCommand;
using static SharpTemplar.Monadic.ArgumentCommands;
using static SharpTemplar.Monadic.ParamsCommands;

public class Program 
{
    public static void Main()
    {
        Markup()
            ._(body)._(enter)
                ._(div)._(@class, "box", "meme")
                ._(div)._(@id, "memes")
        .Print();
    }
}