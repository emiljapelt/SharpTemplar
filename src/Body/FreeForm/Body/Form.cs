namespace SharpTemplar.FreeForm.FormElements
{
    public class Form : HTMLBodyElement
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