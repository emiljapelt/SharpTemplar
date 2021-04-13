using System.Text;
using SharpTemplar.Shared;

namespace SharpTemplar.TableElements
{
    public class TableHead : HTMLTableRowElement
    {
        internal TableHead(HTMLElement parent, string _data)
            : base("th", parent) 
        {
            Contains.Add(new HTMLString(_data));
        }
    }
}