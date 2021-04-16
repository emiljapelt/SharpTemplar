using System.Text;

namespace SharpTemplar.GuidedForm.TableElements
{
    public class TableRow : HTMLTableRowElement
    {
        internal override string TagType => "tr";
        internal TableRow(HTMLElement parent)
            : base(parent) { }
    }
}