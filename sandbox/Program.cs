using static SharpTemplar.Monadic.Bundle.Base;
using static SharpTemplar.Monadic.Bundle.Text;
using static SharpTemplar.Monadic.Bundle.Media;
using static SharpTemplar.Monadic.Bundle.Events;
using SharpTemplar.Monadic;

public class Program 
{
    public static void Main()
    {
        Func<string, Element> link = (l) => 
            small(@class("link"))(
                anchor(@href(l))(
                    text(l)
                ),
                br
            );

        Func<(string, string), Element> userbox = (user) => 
            span(@class("userbox"))(
                p()(
                    text(user.Item1),
                    link($"/{user.Item2}")
                )
            );

        Func<int, Element> canFail = (number) =>
            div()(
                p()(text("Some number should be here:")),
                p()(text($"{100/number}"))
            );

        var navs = new string[] {"www.google.com", "www.bing.com", "www.github.com/emiljapelt/SharpTemplar"};
        var users = new (string,string)[] {("Bob", "@bob_boob"), ("Alice", "@x86_gamer"), ("John", "@johnny_boi"), ("Mike", "@m_dog")};

        var s = Markup(
            head()(),
            body(@on(pageshow, "confetti"))(
                img(src: "logo.jpg", alt: "NO_IMAGE")()(),
                h(2)(@id("title"))(
                    text("BookFace")
                ),
                span(@id("navs"))(
                    OnList(navs, link)
                ),
                Attempt(() => canFail(0), () => text("Ooops")),
                h(3)()(text("Online friends")),
                div(@id("users"))(
                    OnList(users, userbox)
                )
            )
        ).Build();

        Console.WriteLine(s);
    }
}