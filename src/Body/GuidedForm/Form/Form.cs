
namespace SharpTemplar.GuidedForm.FormElements
{
    public class Form : HTMLFormElement
    {
        private string id; 
        internal override string TagType => "form";
        internal Form(HTMLBodyElement parent, string _id)
            : base(parent) 
        {
            id = _id;
        }
    }
}