using System.Text;

namespace Elements.TableElements
{
    public class Table : HTMLTableElement
    {
        internal Table(HTMLBodyElement parent, string[] _colums)
            : base("table", parent) { }

        internal Table(HTMLBodyElement parent)
            : base("table", parent) { }

        internal override void ConstructElement(StringBuilder sb)
        {
            FinishConstruction();
            sb.Append($"<{TagType}");
            foreach(var a in Attributes) sb.Append($" {a.Key}=\"{a.Value}\"");
            sb.Append(">");
            foreach (var td in Contains) td.ConstructElement(sb);
            sb.Append($"</{TagType}>");
        }
    }
}