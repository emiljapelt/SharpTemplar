using System.Text;

namespace Elements.FormElements
{
    public class Form : HTMLFormElement
    {
        private string id; 
        internal Form(HTMLBodyElement parent, string _id)
            : base("form", parent) 
        {
            id = _id;
        }
    }
}