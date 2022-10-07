namespace SharpTemplar.Test;

public class BasicsTests
{
    [Fact]
    public void test()
    {
        new ExposedMonad(Markup()).pointer();
    }
}