using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm
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

    public abstract partial class HTMLBodyElement : HTMLElement
    {
        public HTMLBodyElement AddListItem()
        {
            var li = new ListItem(this);
            AddElement(li);
            return this;
        }
        public HTMLBodyElement AddListItem(string text)
        {
            var li = new ListItem(text, this);
            AddElement(li);
            return this;
        }
        public HTMLBodyElement AddListItem(out HTMLBodyElement saveIn)
        {
            var li = new ListItem(this);
            AddElement(li);
            saveIn = li;
            return this;
        }
        public HTMLBodyElement AddListItem(out HTMLBodyElement saveIn, string text)
        {
            var li = new ListItem(text, this);
            AddElement(li);
            saveIn = li;
            return this;
        }
    }
}