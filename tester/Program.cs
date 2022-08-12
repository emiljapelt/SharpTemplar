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
                .div().@class("box").enter()
                    .p().text("I am a box").exit();
        };

        Functor numbox(int num) {
            return (monad) => {
                return monad
                    .div().@class("box").enter()
                        .p().text($"I am box {num}").exit();
            };
        }

        var s = Markup()
            .head()
            .body().enter()
                .audio().enter()
                    .source("audio/mpeg", "horse.mp3").exit()
                .img("meme.jpg", "just imagine a meme")
                .h(2).@id("1").text("MEMEs")
                .div().@id("2").@class("outerbox").@class("meme").enter()
                    ._(box).exit()
                ._(box)
                ._(numbox(1))
                ._(numbox(2))
        .Build();

        Console.WriteLine(s);
    }
}