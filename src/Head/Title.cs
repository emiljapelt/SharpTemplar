using SharpTemplar.Shared;

namespace SharpTemplar.HeadElements
{
    public class Title : HTMLHeadElement
    {
        internal Title(string content)
            : base("title")
        {
            Contains.Add(new HTMLString(content));
        }
    }
}