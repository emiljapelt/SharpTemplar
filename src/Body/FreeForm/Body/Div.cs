
namespace SharpTemplar.FreeForm
{
    public class Div : HTMLBodyElement
    {
        internal override string TagType => "div";
        internal Div(HTMLBodyElement parent)
                : base(parent) { }
    }

    public abstract partial class HTMLBodyElement : HTMLElement
    {
        /// <summary>
        /// Adds Div into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddDiv()
        {
            var div = new Div(this);
            AddElement(div);
            return this;
        }
        public HTMLBodyElement AddDiv(out HTMLBodyElement saveIn)
        {
            var div = new Div(this);
            saveIn = div;
            AddElement(div);
            return this;
        }
    }
}