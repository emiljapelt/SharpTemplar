namespace SharpTemplar.Test;

public class BaseBundle
{
    [Fact]
    public void AnchorFunctorTest()
    {
        Functor component = (monad) => monad
            .div().Enter()
                .div().Enter();
        
        Functor anchored = Anchor(component);

        Assert.NotEqual(Markup()._(component).text("test").Build(), Markup()._(anchored).text("test").Build());
    }
}