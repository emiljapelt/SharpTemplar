using static SharpTemplar.Monadic.MarkupMonad;
using static SharpTemplar.Monadic.CreationCommands;
using static SharpTemplar.Monadic.ArgumentCommands;
using static SharpTemplar.Monadic.NavigationCommands;
using SharpTemplar.Monadic;

public class Program 
{
    public static void Main()
    {
        Functor box = (monad) => {
            return monad._(div)._(@class("box"))._(enter)
                ._(p)._(text("I am a box"))._(exit);
        };

        Functor numbox(int num) {
            return (monad) => {
                return monad._(div)._(@class("box"))._(enter)
                    ._(p)._(text($"I am box {num}"))._(exit);
            };
        }

        var s = Markup()
            .Body().Enter()
                .Div().@Class("outerbox").@Class("meme").Enter()
                    ._(box).Exit()
                ._(box)
                ._(numbox(1))
                ._(numbox(2))
        .Build();

        Console.WriteLine(s);
    }
}