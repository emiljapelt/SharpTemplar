using System.Text;

namespace Elements.TableElements
{
    public class Table : HTMLTableElement
    {
        internal string [] columns;
        internal Table(HTMLBodyElement parent, string[] _colums)
            : base("table", parent) 
        {
            columns = _colums;
        }

        internal override void ConstructElement(StringBuilder sb)
        {
            FinishConstruction();
            sb.Append($"<{TagType}");
            foreach(var a in Attributes) sb.Append($" {a.Key}=\"{a.Value}\"");
            sb.Append("><tr>");
            foreach (string s in columns) sb.Append($"<th>{s}</th>");
            sb.Append("</tr>");
            foreach (var td in Contains) td.ConstructElement(sb);
            sb.Append($"</{TagType}>");
        }
    }
}