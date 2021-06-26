
namespace SharpTemplar.FreeForm
{
    public class Image : HTMLBodyElement
    {
        internal override string TagType => "img";

        internal Image(string src, HTMLBodyElement parent)
            : base(parent)
        {
            Attributes.Add("src",src);
        }

        internal Image(string src, string alt, HTMLBodyElement parent)
            : base(parent)
        {
            Attributes.Add("src",src);
            Attributes.Add("alt",alt);
        }
    }

    public abstract partial class HTMLBodyElement : HTMLElement
    {
        /// <summary>
        /// Adds Image into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLBodyElement AddImage(string src)
        {           
            var a = new Image(src, this);
            AddElement(a);
            return this;
        }
        public HTMLBodyElement AddImage(string src, string alt)
        {           
            var a = new Image(src, alt, this);
            AddElement(a);
            return this;
        }
    }
}