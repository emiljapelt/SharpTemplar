using System.Text;

namespace Elements.TableElements
{
    public class TableData : HTMLTableElement
    {
        internal string[] data;
        internal TableData(HTMLElement parent, params string[] _data)
            : base("td", parent) 
        {
            data = _data;
        }

        internal override void ConstructElement(StringBuilder sb)
        {
            FinishConstruction();
            sb.Append("<tr");
            foreach(var a in Attributes) sb.Append($" {a.Key}=\"{a.Value}\"");
            sb.Append(">");
            foreach (string s in data) sb.Append($"<{TagType}>{s}</{TagType}>");
            sb.Append("</tr>");
        }
    }
}