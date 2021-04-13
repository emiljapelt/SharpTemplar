using System.Text;

namespace SharpTemplar.TableElements
{
    public class TableRow : HTMLTableRowElement
    {
        internal TableRow(HTMLElement parent)
            : base("tr", parent) { }
    }
}