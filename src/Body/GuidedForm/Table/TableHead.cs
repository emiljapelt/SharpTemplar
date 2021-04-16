using System.Text;
using SharpTemplar.Shared;

namespace SharpTemplar.GuidedForm.TableElements
{
    public class TableHead : HTMLTableRowElement
    {
        internal override string TagType => "th";
        internal TableHead(HTMLElement parent, string _data)
            : base(parent) 
        {
            Contains.Add(new HTMLString(_data));
        }
    }
}