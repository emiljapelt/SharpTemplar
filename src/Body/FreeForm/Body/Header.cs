using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm
{
    public class Header : HTMLBodyElement
    {
        private HeaderLevel level;
        internal override string TagType => "h"+((int)level+1);
        internal Header(HeaderLevel _level, string content, HTMLBodyElement parent)
            : base(parent)
        {
            level = _level;
            Contains.Add(new HTMLString(content));
        }
    }

    public abstract partial class HTMLBodyElement : HTMLElement
    {
        /// <summary>
        /// Adds Header into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddHeader(HeaderLevel level, string content)
        {
            var h = new Header(level, content, this);
            AddElement(h);
            return this;
        }
        public HTMLBodyElement AddHeader(out HTMLBodyElement saveIn, HeaderLevel level, string content)
        {
            var h = new Header(level, content, this);
            saveIn = h;
            AddElement(h);
            return this;
        }
    }
}