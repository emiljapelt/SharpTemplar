using System.Collections.Generic;
using Elements.BodyElements;

namespace Elements
{
    public abstract class HTMLBodyElement : HTMLElement
    {
        internal List<HTMLBodyElement> Container;

        protected HTMLBodyElement()
        {
            Container = new List<HTMLBodyElement>();
        }

        public Paragraph AddParagraph(string content)
        {
            var p = new Paragraph(content);
            Container.Add(p);
            return p;
        }   
    }
}