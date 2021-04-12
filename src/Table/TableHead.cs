using System.Text;
using Elements.Shared;

namespace Elements.TableElements
{
    public class TableHead : HTMLTableDataElement
    {
        internal TableHead(HTMLElement parent, string _data)
            : base("th", parent) 
        {
            Contains.Add(new HTMLString(_data));
        }
    }
}