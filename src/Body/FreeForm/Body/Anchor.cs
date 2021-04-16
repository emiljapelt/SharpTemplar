
namespace SharpTemplar.FreeForm.BodyElements
{
    public class Anchor : HTMLBodyElement
    {
        internal override string TagType => "a";
        internal Anchor(string href, HTMLBodyElement parent)
            : base(parent)
        {
            Attributes.Add("href", href);
        }
    }
}