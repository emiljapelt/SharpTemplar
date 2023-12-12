using SharpTemplar.HyperText;
using static SharpTemplar.HyperText.Base;
using static SharpTemplar.HyperText.Text;
using static SharpTemplar.HyperText.Media;
using static SharpTemplar.HyperText.Events;
using static SharpTemplar.Utility;

namespace SharpTemplar.Sandbox;
public class Program 
{
    public static void Main()
    {
        Component<string> link = (l) => 
            small(@class("link"))(
                anchor(@href(l))(
                    text(l)
                ),
                br
            );

        Component<(string name, string url)> userbox = (user) => 
            span(@class("userbox"))(
                p()(
                    text(user.name),
                    link($"/{user.url}")
                )
            );

        Component<int> canFail = (number) =>
            div()(
                p()(text("Some number should be here:")),
                p()(text($"{100/number}"))
            );

        var navs = new string[] {"www.google.com", "www.bing.com", "www.github.com/emiljapelt/SharpTemplar"};
        var users = new (string,string)[] {("Bob", "@bob_boob"), ("Alice", "@x86_gamer"), ("John", "@johnny_boi"), ("Mike", "@m_dog")};

        var s = HTML(
            head()(),
            body(@on(pageshow, "confetti"))(
                If(true, _(p()(text("meme1")), p()(text("meme2")))),
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