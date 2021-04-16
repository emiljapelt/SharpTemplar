using System.Text;
using SharpTemplar.FreeForm.BodyElements;

namespace SharpTemplar
{
    public class FreeFormDocument : TemplarDocument
    {
        public Body Body;
        internal override HTMLElement _Body { get { return (HTMLElement) Body;} }

        public FreeFormDocument(string title)
            : base(title)
        {
            Body = new Body();
        }
    }
}