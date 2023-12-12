namespace SharpTemplar.Test;

public class UtilityTests
{
    [Fact]
    public void nothing_does_nothing()
    {
        Assert.Equal(
            HTML(
                body()(nothing)
            ).Build(),

            HTML(
                body()()
            ).Build()
        );
    }

    [Fact]
    public void IfElse_true_test()
    {
        Assert.Equal(
            HTML(
                body()(
                    If(true, div()(), span()())
                )
            ).Build(),

            HTML(
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
            HTML(
                body()(
                    If(false, div()(), span()())
                )
            ).Build(),

            HTML(
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
            HTML(
                body()(
                    If(true, div()())
                )
            ).Build(),

            HTML(
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
            HTML(
                body()(
                    If(false, div()())
                )
            ).Build(),

            HTML(
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
            HTML(
                body()(
                    Attempt(() => div()(), () => span()())
                )
            ).Build(),

            HTML(
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
            HTML(
                body()(
                    Attempt(() => component(0), () => span()())
                )
            ).Build(),

            HTML(
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
            HTML(
                body()(
                    Attempt(() => div()())
                )
            ).Build(),
            
            HTML(
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
            HTML(
                body()(
                    Attempt(() => component(0))
                )
            ).Build(),

            HTML(
                body()(
                    nothing
                )
            ).Build()
        );
    }

    [Fact]
    public void RangeWithIndex_0_to_count_test()
    {
        Component<int> component = (i) => text($"{i}");

        Assert.Equal(
            HTML(
                body()(
                    Range(4, component)
                )
            ).Build(),

            HTML(
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
            HTML(
                body()(
                    Range(4, text("test"))
                )
            ).Build(),

            HTML(
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
        Component<int> component = (i) => text($"{i}");

        Assert.Equal(
            HTML(
                body()(
                    Range(10, 4, component)
                )
            ).Build(),

            HTML(
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
            HTML(
                body()(
                    Range(10, 4, text("test"))
                )
            ).Build(),

            HTML(
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
            HTML(
                body()(
                    OnList(words, text)
                )
            ).Build(),

            HTML(
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