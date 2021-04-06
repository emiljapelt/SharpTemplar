using System.Text;

namespace Elements
{
    public abstract class HTMLElement
    {
        public string ElementTag { get; set; }
        public string ElementClass { get; set; }

        internal abstract void ConstructElement(StringBuilder sb);
    }
}