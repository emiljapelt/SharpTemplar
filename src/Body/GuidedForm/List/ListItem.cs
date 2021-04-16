using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.ListElements
{
    public class ListItem : HTMLBodyElement
    {
        internal override string TagType => "li";
        internal ListItem(HTMLListElement parent)
            : base(parent) 
        { 
            Parent = this;
        }

        internal ListItem(string text, HTMLListElement parent)
            : base(parent) 
        {
            Parent = this;
            Contains.Add(new HTMLString(text));
        }
    }
}