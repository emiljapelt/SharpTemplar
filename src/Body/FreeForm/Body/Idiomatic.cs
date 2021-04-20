
namespace SharpTemplar.FreeForm.BodyElements
{
    public class Idiomatic : HTMLBodyElement
    {
        internal override string TagType => "i";
        internal Idiomatic(HTMLBodyElement parent)
                : base(parent) { }
    }
}