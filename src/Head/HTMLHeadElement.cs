using SharpTemplar.Shared;

namespace SharpTemplar.HeadElements
{
    public abstract class HTMLHeadElement : HTMLElement
    {
        private HTMLHeadElement _Parent;
        internal override HTMLElement Parent 
        { 
            get { return _Parent; }
            set { _Parent = (HTMLHeadElement) value; }
        }
        private HTMLHeadElement _Newest;
        internal override HTMLElement Newest 
        { 
            get { return _Newest; }
            set { _Newest = (HTMLHeadElement) value; }
        }


        protected HTMLHeadElement(string tagType)
            : base(tagType, null) { }


        /// <summary>
        /// Adds attribute of any kind to the Element it is called on. If the Element already has the attribute, the old attribute is replaced.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>        
        public HTMLHeadElement WithAttribute(string key, string value)
        {
            AddAttribute(key, value);
            return this;
        }

        /// <summary>
        /// Adds text into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLHeadElement InsertHTMLString(string content)
        {
            FinishConstruction();
            Contains.Add(new HTMLString(content));
            return this;
        }

        /// <summary>
        /// Adds Style into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLHeadElement AddStyle(string path)
        {
            var style = new Style(path);
            AddElement(style);
            return this;
        }

        /// <summary>
        /// Adds Meta into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLHeadElement AddMeta()
        {
            var meta = new Meta();
            AddElement(meta);
            return this;
        }

        /// <summary>
        /// Adds Link into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLHeadElement AddLink(string rel, string href)
        {
            var link = new Link(rel, href);
            AddElement(link);
            return this;
        }

        /// <summary>
        /// Adds Script into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLHeadElement AddScript(string path)
        {
            var script = new Script(path);
            AddElement(script);
            return this;
        }

        /// <summary>
        /// Adds Script into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLHeadElement AddScript()
        {
            var script = new Script();
            AddElement(script);
            return this;
        }
    }
}