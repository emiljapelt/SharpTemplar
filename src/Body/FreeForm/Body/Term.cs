
namespace SharpTemplar.FreeForm
{
    public class Term : HTMLBodyElement
    {
        internal override string TagType => "dt";
        internal Term(HTMLBodyElement parent)
            : base(parent) { }
    }
    
    public abstract partial class HTMLBodyElement : HTMLElement
    {
        public HTMLBodyElement AddTerm()
        {
            var dt = new Term(this);
            AddElement(dt);
            return this;
        }
        public HTMLBodyElement AddTerm(out HTMLBodyElement saveIn)
        {
            var dt = new Term(this);
            saveIn = dt;
            AddElement(dt);
            return this;
        }
    }
}