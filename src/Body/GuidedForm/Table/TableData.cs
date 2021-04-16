using System.Text;
using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.TableElements
{
    public class TableData : HTMLTableRowElement
    {
        internal override string TagType => "td";
        internal TableData(HTMLElement parent, string _data)
            : base(parent) 
        {
            Contains.Add(new HTMLString(_data));
        }
    }
}