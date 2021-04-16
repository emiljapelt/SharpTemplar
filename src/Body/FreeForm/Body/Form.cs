
namespace SharpTemplar.FreeForm.BodyElements
{
    public class Form : HTMLBodyElement
    {
        private string id;
        internal override string TagType => "form";
        internal Form(string _id, HTMLBodyElement parent)
            : base(parent) 
        {
            id = _id;
        }
    }
}