using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm.BodyElements
{
    public class Header : HTMLBodyElement
    {
        private HeaderLevel level;
        internal override string TagType => "h"+((int)level+1);
        internal Header(HeaderLevel _level, string content, HTMLBodyElement parent)
            : base(parent)
        {
            level = _level;
            Contains.Add(new HTMLString(content));
        }
    }
}