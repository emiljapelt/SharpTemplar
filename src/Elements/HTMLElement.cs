using System.Collections.Generic;

namespace Elements
{
    public abstract class HTMLElement
    {
        public string ElementTag { get; set; }
        public string ElementClass { get; set; }
        public List<HTMLElement> Container { get; set; }

        public Paragraph AddParagraph(string content)
        {
            var p = new Paragraph(content);
            Container.Add(p);
            return p;
        }
    }
}