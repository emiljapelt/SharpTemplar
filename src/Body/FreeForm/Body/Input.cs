namespace SharpTemplar.FreeForm.FormElements
{
    public class Input : HTMLBodyElement
    {
        internal override string TagType => "input";
        internal Input(string id, string type, HTMLElement parent)
            : base(parent)
        {
            Attributes.Add("type", type);
            Attributes.Add("id", id);
        }
    }
}