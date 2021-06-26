
namespace SharpTemplar.FreeForm
{
    public class Idiomatic : HTMLBodyElement
    {
        internal override string TagType => "i";
        internal Idiomatic(HTMLBodyElement parent)
                : base(parent) { }
    }

    public abstract partial class HTMLBodyElement : HTMLElement
    {
        public HTMLBodyElement AddIdiomatic()
        {
            var i = new Idiomatic(this);
            AddElement(i);
            return this;
        }
        public HTMLBodyElement AddIdiomatic(out HTMLBodyElement saveIn)
        {
            var i = new Idiomatic(this);
            saveIn = i;
            AddElement(i);
            return this;
        }
    }
}