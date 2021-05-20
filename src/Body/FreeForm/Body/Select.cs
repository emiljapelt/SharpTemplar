
namespace SharpTemplar.FreeForm.BodyElements
{
    public class Select : HTMLBodyElement
    {
        internal override string TagType => "select";
        internal Select(string name, HTMLElement parent)
            : base(parent)
        {
            Attributes.Add("name", name);
        }
    }
}