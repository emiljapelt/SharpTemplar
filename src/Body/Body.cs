
namespace Elements.BodyElements
{
    public class Body : HTMLBodyElement
    {
        internal Body()
            : base ("body", null)
        {
            Parent = this;
        }
    }
}