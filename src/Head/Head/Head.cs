
namespace SharpTemplar.HeadElements
{
    public class Head : HTMLHeadElement
    {
        internal override string TagType => "head";
        internal Head(string title)
            : base()
        {
            Contains.Add(new Title(title));
        }
    }
}