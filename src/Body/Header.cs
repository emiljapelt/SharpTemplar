using SharpTemplar.Shared;

namespace SharpTemplar.BodyElements
{
    public class Header : HTMLBodyElement
    {
        internal Header(string level, string content, HTMLBodyElement parent)
            : base("h"+level, parent)
        {
            Contains.Add(new HTMLString(content));
        }
    }
}