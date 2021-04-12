using System.Text;
using Elements.Shared;

namespace Elements.TableElements
{
    public class TableData : HTMLTableRowElement
    {
        internal TableData(HTMLElement parent, string _data)
            : base("td", parent) 
        {
            Contains.Add(new HTMLString(_data));
        }
    }
}