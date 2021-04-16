
namespace SharpTemplar.GuidedForm.FormElements
{
    public class Input : HTMLFormElement
    {
        internal Input(string id, string type, HTMLElement parent)
            : base("input", parent)
        {
            Attributes.Add("type", type);
            Attributes.Add("id", id);
        }
    }
}