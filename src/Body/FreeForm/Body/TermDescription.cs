
namespace SharpTemplar.FreeForm
{
    public class TermDescription : HTMLBodyElement
    {
        internal override string TagType => "dd";
        internal TermDescription(HTMLBodyElement parent)
            : base(parent) { }
    }

    public abstract partial class HTMLBodyElement : HTMLElement
    {
        public HTMLBodyElement AddTermDescription()
        {
            var dd = new TermDescription(this);
            AddElement(dd);
            return this;
        }
        public HTMLBodyElement AddTermDescription(out HTMLBodyElement saveIn)
        {
            var dd = new TermDescription(this);
            saveIn = dd;
            AddElement(dd);
            return this;
        }
    }
}