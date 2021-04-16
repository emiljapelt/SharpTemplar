
namespace SharpTemplar.FreeForm.BodyElements
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
}