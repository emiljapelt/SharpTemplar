using System.Text;
using SharpTemplar.GuidedForm.BodyElements;

namespace SharpTemplar.GuidedForm
{
    public class GuidedFormDocument : TemplarDocument
    {
        public Body Body;
        internal override HTMLElement _Body { get { return (HTMLElement) Body;} }

        public GuidedFormDocument(string title)
            : base(title)
        {
            Body = new Body();
        }
    }
}