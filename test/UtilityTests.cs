namespace SharpTemplar.Test;

public class UtilityTests
{
    [Fact]
    public void Enter_no_newest_test()
    {
        Assert.True(
            Markup().Enter() is MarkupFailure
        );
    }

    [Fact]
    public void Exit_no_parent_test()
    {
        Assert.True(
            Markup().Exit() is MarkupFailure
        );
    }

    [Fact]
    public void text_into_newest_test()
    {
        Assert.Equal(
            Markup().p().text("test").Build(),
            Markup().p().Enter().text("test").Build()
        );
    }

    [Fact]
    public void Anchor_test()
    {
        Functor component = (monad) => monad
            .div().Enter()
                .div().Enter();
        
        Functor anchored = Anchor(component);

        Assert.NotEqual(
            Markup()._(component).text("test").Build(), 
            Markup()._(anchored).text("test").Build()
        );
    }

    [Fact]
    public void IfElse_true_test()
    {
        Assert.Equal(
            Markup().If(true, Div, Span).Build(),
            Markup().div().Build()
        );
    }

    [Fact]
    public void IfElse_false_test()
    {
        Assert.Equal(
            Markup().If(false, Div, Span).Build(),
            Markup().span().Build()
        );
    }

    [Fact]
    public void If_true_test()
    {
        Assert.Equal(
            Markup().If(true, Div).Build(),
            Markup().div().Build()
        );
    }

    [Fact]
    public void If_false_test()
    {
        Assert.Equal(
            Markup().If(false, Div).Build(),
            Markup()._(nothing).Build()
        );
    }

    [Fact]
    public void AttemptAlternative_success_test()
    {
        Assert.Equal(
            Markup().Attempt(Div,Span).Build(),
            Markup().div().Build()
        );
    }

    [Fact]
    public void AttemptAlternative_fail_test()
    {
        Func<int, Functor> component = (i) => (monad) => monad.text($"{100/i}");

        Assert.Equal(
            Markup().Attempt(component(0),Span).Build(),
            Markup().span().Build()
        );
    }

    [Fact]
    public void Attempt_success_test()
    {
        Assert.Equal(
            Markup().Attempt(Div).Build(),
            Markup().div().Build()
        );
    }

    [Fact]
    public void Attempt_fail_test()
    {
        Func<int, Functor> component = (i) => (monad) => monad.text($"{100/i}");

        Assert.Equal(
            Markup().Attempt(component(0)).Build(),
            Markup()._(nothing).Build()
        );
    }

    [Fact]
    public void RangeWithIndex_0_to_count_test()
    {
        Func<int, Functor> component = (i) => (monad) => monad.text($"{i}");

        Assert.Equal(
            Markup().Range(4, component).Build(),
            Markup()._(component(0))._(component(1))._(component(2))._(component(3)).Build()
        );
    }

    [Fact]
    public void RangeWithoutIndex_0_to_count_test()
    {
        Functor component = (monad) => monad.text($"test");

        Assert.Equal(
            Markup().Range(4, component).Build(),
            Markup()._(component)._(component)._(component)._(component).Build()
        );
    }

    [Fact]
    public void RangeWithIndex_start_to_count_test()
    {
        Func<int, Functor> component = (i) => (monad) => monad.text($"{i}");

        Assert.Equal(
            Markup().Range(10, 4, component).Build(),
            Markup()._(component(10))._(component(11))._(component(12))._(component(13)).Build()
        );
    }

    [Fact]
    public void RangeWithoutIndex_start_to_count_test()
    {
        Functor component = (monad) => monad.text($"test");

        Assert.Equal(
            Markup().Range(10, 4, component).Build(),
            Markup()._(component)._(component)._(component)._(component).Build()
        );
    }

    [Fact]
    public void OnList_test()
    {
        var words = new string[] {"hi", "hello", "hey", "bye"};
        Func<string, Functor> component = (w) => (monad) => monad.text($"test");

        Assert.Equal(
            Markup().OnList(words, component).Build(),
            Markup()._(component(words[0]))._(component(words[1]))._(component(words[2]))._(component(words[3])).Build()
        );
    }
}