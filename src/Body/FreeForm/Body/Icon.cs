
namespace SharpTemplar.FreeForm.BodyElements
{
    public class Icon : HTMLBodyElement
    {
        internal override string TagType => "i";
        internal Icon(HTMLBodyElement parent)
                : base(parent) { }
    }
}