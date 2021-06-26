
namespace SharpTemplar
{
    public class Meta : HTMLHeadElement
    {
        internal override string TagType => "meta";
        internal Meta()
            : base() { }
    }

    public abstract partial class HTMLHeadElement : HTMLElement
    {
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
    }
}