using SharpTemplar.Shared;

namespace SharpTemplar.ListElements
{
    public class ListItem : HTMLBodyElement
    {
        internal ListItem(HTMLListElement parent)
            : base("li", parent) { }
    }
}