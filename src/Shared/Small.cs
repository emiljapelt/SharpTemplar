
namespace SharpTemplar.Shared
{
    public class Small : HTMLBodyElement
    {

        internal Small(string content, HTMLElement parent)
            : base("small", parent)
        {
            Contains.Add(new HTMLString(content));
        }
    }
}