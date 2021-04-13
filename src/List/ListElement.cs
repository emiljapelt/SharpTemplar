using SharpTemplar.Shared;

namespace SharpTemplar.ListElements
{
    public class ListElement : HTMLListItemElement
    {
        internal ListElement(HTMLListElement parent)
            : base("li", parent) { }
    }
}