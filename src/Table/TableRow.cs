using System.Text;

namespace Elements.TableElements
{
    public class TableRow : HTMLTableRowElement
    {
        internal TableRow(HTMLElement parent)
            : base("tr", parent) { }
    }
}