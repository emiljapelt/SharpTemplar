using System.Text;

namespace SharpTemplar.GuidedForm.TableElements
{
    public class TableRow : HTMLTableRowElement
    {
        internal TableRow(HTMLElement parent)
            : base("tr", parent) { }
    }
}