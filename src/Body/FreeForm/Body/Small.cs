using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm
{
    public class Small : HTMLBodyElement
    {
        internal override string TagType => "small";
        internal Small(HTMLBodyElement parent)
            : base (parent) { }

        internal Small(string text, HTMLBodyElement parent)
            : base (parent) 
        {
            Contains.Add(new HTMLString(text));
        }
    }

    public abstract partial class HTMLBodyElement : HTMLElement
    {
        /// <summary>
        /// Adds Small into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddSmall()
        {
            var small = new Small(this);
            AddElement(small);
            return this;
        }
        public HTMLBodyElement AddSmall(out HTMLBodyElement saveIn)
        {
            var small = new Small(this);
            saveIn = small;
            AddElement(small);
            return this;
        }
        public HTMLBodyElement AddSmall(string text)
        {
            var small = new Small(text, this);
            AddElement(small);
            return this;
        }
        public HTMLBodyElement AddSmall(out HTMLBodyElement saveIn, string text)
        {
            var small = new Small(text, this);
            saveIn = small;
            AddElement(small);
            return this;
        }
    }
}