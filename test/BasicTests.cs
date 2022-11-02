namespace SharpTemplar.Test;

public class BasicsTests
{
    [Fact]
    public void is_inside_directly()
    {
        var b = new HTMLtag("body");
        var a = new HTMLtag("a", b);
        b.AddChild(a);

        var exposed = new ExposedMonad(new MarkupSuccess(a, new HashSet<string>()));

        Assert.True(exposed.isInside("a"));
    }

    [Fact]
    public void is_inside_nested()
    {
        var b = new HTMLtag("body");
        var d = new HTMLtag("div", b);
        var a = new HTMLtag("a", d);
        b.AddChild(d);
        d.AddChild(a);
        
        var exposed = new ExposedMonad(new MarkupSuccess(a, new HashSet<string>()));

        Assert.True(exposed.isInside("body"));
    }

    [Fact]
    public void is_inside_directly_false()
    {
        var b = new HTMLtag("body");
        var a = new HTMLtag("a", b);
        b.AddChild(a);

        var exposed = new ExposedMonad(new MarkupSuccess(a, new HashSet<string>()));

        Assert.False(exposed.isInside("span"));
    }

    [Fact]
    public void is_inside_nested_false()
    {
        var b = new HTMLtag("body");
        var d = new HTMLtag("div", b);
        var a = new HTMLtag("a", d);
        b.AddChild(d);
        d.AddChild(a);
        
        var exposed = new ExposedMonad(new MarkupSuccess(a, new HashSet<string>()));

        Assert.False(exposed.isInside("span"));
    }

    [Fact]
    public void is_inside_wrong_branch()
    {
        var b = new HTMLtag("body");
        var d = new HTMLtag("div", b);
        var s = new HTMLtag("span", d);
        var a = new HTMLtag("a", b);
        
        var exposed = new ExposedMonad(new MarkupSuccess(a, new HashSet<string>()));

        Assert.False(exposed.isInside("span"));
    }

    [Fact]
    public void ids_are_unique()
    {
        Assert.Equal(
            "Id 'hello' is already in use!",
            Markup(
                body(@id("hello"))(
                    anchor(@id("hello"))()
                )
            ).Build()
        );
    }
}