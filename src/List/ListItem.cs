using SharpTemplar.Shared;

namespace SharpTemplar.ListElements
{
    public class ListItem : HTMLBodyElement
    {
        internal ListItem(HTMLListElement parent)
            : base("li", parent) 
        { 
            Parent = this;
        }

        internal ListItem(string text, HTMLListElement parent)
            : base("li", parent) 
        {
            Parent = this;
            Contains.Add(new HTMLString(text));
        }
    }
}