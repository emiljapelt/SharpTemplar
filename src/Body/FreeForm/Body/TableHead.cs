using System.Text;
using SharpTemplar.Shared;

namespace SharpTemplar.FreeForm.BodyElements
{
    public class TableHead : HTMLBodyElement
    {
        internal override string TagType => "th";

        internal TableHead(HTMLBodyElement parent)
            : base(parent) { }

        internal TableHead(string text, HTMLBodyElement parent)
            : base(parent) 
        {
            Contains.Add(new HTMLString(text));
        }
    }
}