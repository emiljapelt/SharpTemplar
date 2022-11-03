namespace SharpTemplar.Test;

public class BasicsTests
{
    [Fact]
    public void is_inside_directly()
    {
        var b = new XMLtag("body");
        var a = new XMLtag("a", b);
        b.AddChild(a);

        var exposed = new ExposedState(new MarkupSuccess(a, new HashSet<string>()));

        Assert.True(exposed.isInside("a"));
    }

    [Fact]
    public void is_inside_nested()
    {
        var b = new XMLtag("body");
        var d = new XMLtag("div", b);
        var a = new XMLtag("a", d);
        b.AddChild(d);
        d.AddChild(a);
        
        var exposed = new ExposedState(new MarkupSuccess(a, new HashSet<string>()));

        Assert.True(exposed.isInside("body"));
    }

    [Fact]
    public void is_inside_directly_false()
    {
        var b = new XMLtag("body");
        var a = new XMLtag("a", b);
        b.AddChild(a);

        var exposed = new ExposedState(new MarkupSuccess(a, new HashSet<string>()));

        Assert.False(exposed.isInside("span"));
    }

    [Fact]
    public void is_inside_nested_false()
    {
        var b = new XMLtag("body");
        var d = new XMLtag("div", b);
        var a = new XMLtag("a", d);
        b.AddChild(d);
        d.AddChild(a);
        
        var exposed = new ExposedState(new MarkupSuccess(a, new HashSet<string>()));

        Assert.False(exposed.isInside("span"));
    }

    [Fact]
    public void is_inside_wrong_branch()
    {
        var b = new XMLtag("body");
        var d = new XMLtag("div", b);
        var s = new XMLtag("span", d);
        var a = new XMLtag("a", b);
        
        var exposed = new ExposedState(new MarkupSuccess(a, new HashSet<string>()));

        Assert.False(exposed.isInside("span"));
    }

    [Fact]
    public void ids_are_unique()
    {
        Assert.Equal(
            "Id 'hello' is already in use!",
            HTML(
                body(@id("hello"))(
                    anchor(@id("hello"))()
                )
            ).Build()
        );
    }
}