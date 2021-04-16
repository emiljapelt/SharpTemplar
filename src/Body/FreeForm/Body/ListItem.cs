using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm.ListElements
{
    public class ListItem : HTMLBodyElement
    {
        internal override string TagType => "li";
        internal ListItem(HTMLBodyElement parent)
            : base(parent) 
        { 
            Parent = this;
        }

        internal ListItem(string text, HTMLBodyElement parent)
            : base(parent) 
        {
            Parent = this;
            Contains.Add(new HTMLString(text));
        }
    }
}