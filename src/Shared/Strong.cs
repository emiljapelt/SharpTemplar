
namespace SharpTemplar.Shared
{
    public class Strong : HTMLBodyElement
    {

        internal Strong(string content, HTMLElement parent)
            : base("strong", parent)
        {
            Contains.Add(new HTMLString(content));
        }
    }
}