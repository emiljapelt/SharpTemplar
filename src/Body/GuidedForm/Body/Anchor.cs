
namespace SharpTemplar.GuidedForm.BodyElements
{
    public class Anchor : HTMLBodyElement
    {
        internal Anchor(string href, HTMLBodyElement parent)
            : base("a", parent)
        {
            Attributes.Add("href", href);
        }
    }
}