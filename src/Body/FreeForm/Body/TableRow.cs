
namespace SharpTemplar.FreeForm.BodyElements
{
    public class TableRow : HTMLBodyElement
    {
        internal override string TagType => "tr";
        
        internal TableRow(HTMLElement parent)
            : base(parent) { }
    }
}