namespace SharpTemplar.Test;

public class UtilityTests
{
    [Fact]
    public void nothing_does_nothing()
    {
        Assert.Equal(
            Markup(
                body()(nothing)
            ).Build(),

            Markup(
                body()()
            ).Build()
        );
    }

    [Fact]
    public void IfElse_true_test()
    {
        Assert.Equal(
            Markup(
                body()(
                    If(true, div()(), span()())
                )
            ).Build(),

            Markup(
                body()(
                    div()()
                )
            ).Build()
        );
    }

    [Fact]
    public void IfElse_false_test()
    {
        Assert.Equal(
            Markup(
                body()(
                    If(false, div()(), span()())
                )
            ).Build(),

            Markup(
                body()(
                    span()()
                )
            ).Build()
        );
    }

    [Fact]
    public void If_true_test()
    {
        Assert.Equal(
            Markup(
                body()(
                    If(true, div()())
                )
            ).Build(),

            Markup(
                body()(
                    div()()
                )
            ).Build()
        );
    }

    [Fact]
    public void If_false_test()
    {
        Assert.Equal(
            Markup(
                body()(
                    If(false, div()())
                )
            ).Build(),

            Markup(
                body()(
                    nothing
                )
            ).Build()
        );
    }

    [Fact]
    public void AttemptAlternative_success_test()
    {
        Assert.Equal(
            Markup(
                body()(
                    Attempt(() => div()(), () => span()())
                )
            ).Build(),

            Markup(
                body()(
                    div()()
                )
            ).Build()
        );
    }

    [Fact]
    public void AttemptAlternative_fail_test()
    {
        Func<int, Element> component = (i) => text($"{100/i}");

        Assert.Equal(
            Markup(
                body()(
                    Attempt(() => component(0), () => span()())
                )
            ).Build(),

            Markup(
                body()(
                    span()()
                )
            ).Build()
        );
    }

    [Fact]
    public void Attempt_success_test()
    {
        Assert.Equal(
            Markup(
                body()(
                    Attempt(() => div()())
                )
            ).Build(),
            
            Markup(
                body()(
                    div()()
                )
            ).Build()
        );
    }

    [Fact]
    public void Attempt_fail_test()
    {
        Func<int, Element> component = (i) => text($"{100/i}");

        Assert.Equal(
            Markup(
                body()(
                    Attempt(() => component(0))
                )
            ).Build(),

            Markup(
                body()(
                    nothing
                )
            ).Build()
        );
    }

    [Fact]
    public void RangeWithIndex_0_to_count_test()
    {
        Func<int, Element> component = (i) => text($"{i}");

        Assert.Equal(
            Markup(
                body()(
                    Range(4, component)
                )
            ).Build(),

            Markup(
                body()(
                    component(0),
                    component(1),
                    component(2),
                    component(3)
                )
            ).Build()
        );
    }

    [Fact]
    public void RangeWithoutIndex_0_to_count_test()
    {
        Assert.Equal(
            Markup(
                body()(
                    Range(4, text("test"))
                )
            ).Build(),

            Markup(
                body()(
                    text("test"),
                    text("test"),
                    text("test"),
                    text("test")
                )
            ).Build()
        );
    }

    [Fact]
    public void RangeWithIndex_start_to_count_test()
    {
        Func<int, Element> component = (i) => text($"{i}");

        Assert.Equal(
            Markup(
                body()(
                    Range(10, 4, component)
                )
            ).Build(),

            Markup(
                body()(
                    component(10),
                    component(11),
                    component(12),
                    component(13)
                )
            ).Build()
        );
    }

    [Fact]
    public void RangeWithoutIndex_start_to_count_test()
    {
        Assert.Equal(
            Markup(
                body()(
                    Range(10, 4, text("test"))
                )
            ).Build(),

            Markup(
                body()(
                    text("test"),
                    text("test"),
                    text("test"),
                    text("test")
                )
            ).Build()
        );
    }

    [Fact]
    public void OnList_test()
    {
        var words = new string[] {"hi", "hello", "hey", "bye"};

        Assert.Equal(
            Markup(
                body()(
                    OnList(words, text)
                )
            ).Build(),

            Markup(
                body()(
                    text(words[0]),
                    text(words[1]),
                    text(words[2]),
                    text(words[3])
                )
            ).Build()
        );
    }
}