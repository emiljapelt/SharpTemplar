using static SharpTemplar.Monadic.MarkupMonad;
using static SharpTemplar.Monadic.CreationCommand;
using static SharpTemplar.Monadic.NavigationCommand;
using static SharpTemplar.Monadic.ArgumentCommands;
using static SharpTemplar.Monadic.ParamsCommands;

using System.Text;

public class Program 
{
    public static void Main()
    { 
        var s = Markup()
            ._(body)._(enter)
                ._(div)._(@class, "box", "meme")
                ._(div)._(@id, "memes")
        .Build();

        Console.WriteLine(s);
    }
}