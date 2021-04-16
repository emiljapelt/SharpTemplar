using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm.BodyElements
{
    public class TableData : HTMLBodyElement
    {
        internal override string TagType => "td";
        
        internal TableData(HTMLBodyElement parent)
            : base(parent) { }

        internal TableData(string text, HTMLBodyElement parent)
            : base(parent) 
        {
            Contains.Add(new HTMLString(text));
        }
    }
}