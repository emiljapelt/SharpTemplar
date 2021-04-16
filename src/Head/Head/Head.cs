
namespace SharpTemplar.HeadElements
{
    public class Head : HTMLHeadElement
    {
        internal Head(string title)
            : base("head")
        {
            Contains.Add(new Title(title));
        }
    }
}