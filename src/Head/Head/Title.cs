using SharpTemplar.Shared;

namespace SharpTemplar.HeadElements
{
    public class Title : HTMLHeadElement
    {
        internal override string TagType => "title";
        internal Title(string content)
            : base()
        {
            Contains.Add(new HTMLString(content));
        }
    }
}