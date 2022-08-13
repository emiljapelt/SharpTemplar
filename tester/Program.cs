using static SharpTemplar.Monadic.Bundle.Base;
using static SharpTemplar.Monadic.Bundle.Text;
using static SharpTemplar.Monadic.Bundle.Media;
using SharpTemplar.Monadic;

public class Program 
{
    public static void Main()
    {
        Functor box = (monad) => {
            return monad
                .div().@class("box").Enter()
                    .p().text("I am a box").Exit();
        };

        Functor numbox(int num) {
            return (monad) => {
                return monad
                    .div().@class("box").Enter()
                        .p().text($"I am box {num}").Exit();
            };
        }

        var s = Markup()
            .head()
            .body().Enter()
                .audio().Enter()
                    .source("audio/mpeg", "horse.mp3").Exit()
                .img("meme.jpg", "just imagine a meme")
                .h(2).@id("1").text("MEMEs")
                .div().@id("2").@class("outerbox").@class("meme").Enter()
                    ._(box).Exit()
                ._(box)
                .Range(4, (i) => numbox(i))
        .Build();

        Console.WriteLine(s);
    }
}