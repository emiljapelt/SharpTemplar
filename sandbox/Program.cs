using static SharpTemplar.Monadic.Bundle.Base;
using static SharpTemplar.Monadic.Bundle.Text;
using static SharpTemplar.Monadic.Bundle.Media;
using static SharpTemplar.Monadic.Bundle.Events;
using SharpTemplar.Monadic;

public class Program 
{
    public static void Main()
    {
        Functor noExit = (monad) => monad
            .span().Enter()
                .span().Enter();
        
        Functor fix = AnchorFunctor(noExit);

        Func<string, Functor> link = (l) => (monad) => monad
                .small().@class("link").Enter()
                    .a().@href(l).text(l).Exit();

        Func<(string, string), Functor> userbox = (user) => (monad) => monad
            .span().@class("userbox").Enter()
                .p().text(user.Item1).Enter()._(link($"/{user.Item2}")).Exit().Exit();

        Func<int, Functor> canFail = (number) => (monad) => monad
            .p().text("Some number shold be here:")
            .p().text($"{100/number}");

        var navs = new string[] {"www.google.com", "www.bing.com", "www.github.com/emiljapelt/SharpTemplar"};
        var users = new (string,string)[] {("Bob", "@bob_boob"), ("Alice", "@x86_gamer"), ("John", "@johnny_boi"), ("Mike", "@m_dog")};

        // var s = Markup()
        //     .head()
        //     .body().@on(pageshow, "confetti").Enter()
        //         .img(src: "logo.jpg", alt: "NO_IMAGE")
        //         .h(2).@id("title").text("BookFace")
        //         .span().@id("navs").Enter()
        //             .OnList(navs, (l) => (monad) => {return monad._(link(l)).text(" | ");}).Exit()
        //         .Attempt(canFail(1), (monad) => monad.p().text("Ooops"))
        //         ._(fix)
        //         ._(noExit)
        //         .h(3).text("Online friends")
        //         .div().@id("users").Enter()
        //             .OnList(users, userbox)
        // .Build();

        var s = Markup()
            .body().Enter()
                .span().Enter()
                .Attempt((m) => m.Exit()._(canFail(10)), (m) => m.p("Failed"));

        Console.WriteLine(s.Build());
    }
}