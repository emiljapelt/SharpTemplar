
namespace SharpTemplar.FreeForm
{
    public class Body : HTMLBodyElement
    {
        internal override string TagType => "body";
        internal Body()
            : base (null)
        {
            Parent = this;
        }
    }
}