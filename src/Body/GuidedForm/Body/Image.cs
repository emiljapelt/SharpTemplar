using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.BodyElements
{
    public class Image : HTMLBodyElement
    {

        internal Image(string src, HTMLBodyElement parent)
            : base("img", parent)
        {
            Attributes.Add("src",src);
        }

        internal Image(string src, string alt, HTMLBodyElement parent)
            : base("img", parent)
        {
            Attributes.Add("src",src);
            Attributes.Add("alt",alt);
        }
    }
}