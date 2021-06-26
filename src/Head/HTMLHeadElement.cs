using SharpTemplar.Shared;

namespace SharpTemplar
{
    public abstract partial class HTMLHeadElement : HTMLElement
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


        protected HTMLHeadElement()
            : base(null) { }


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
        /// Adds text into the Element under construction.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLHeadElement InjectHTMLString(string content)
        {
            Newest.Contains.Add(new HTMLString(content));
            return this;
        }
    }
}