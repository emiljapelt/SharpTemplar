using static SharpTemplar.Monadic.Bundle.Base;
using static SharpTemplar.Monadic.Bundle.Text;
using static SharpTemplar.Monadic.Bundle.Media;
using SharpTemplar.Monadic;

public class Program 
{
    public static void Main()
    {
        Functor box = (monad) => monad
            .div().@class("box").Enter()
                .p().text("I am a box").Exit();

        Functor numbox(int num) { return (monad) => monad
                .div().@class("box").Enter()
                    .p().text($"I am box {num}").Exit();
        }

        Func<string, Functor> meme = (name) => (monad) => monad
            .div().@class("userbox").Enter()
                .p().text(name).Exit();

        Functor namedbox(string name) { return (monad) => monad
                .div().@class("userbox").Enter()
                    .p().text(name).Exit();
        }

        var users = new string[] {"Bob", "Alice", "John", "Mike"};

        var s = Markup()
            .head()
            .body().Enter()
                .audio().Enter()
                    .source(type: "audio/mpeg", src: "horse.mp3").Exit()
                .img(src: "meme.jpg", alt: "just imagine a meme")
                .h(2).@id("1").text("MEMEs")
                .div().@id("2").@class("outerbox").@class("meme").Enter()
                    ._(box).Exit()
                ._(box)
                .Range(4, (i) => numbox(i))
                .OnList(users, namedbox)
        .Build();

        Console.WriteLine(s);
    }
}