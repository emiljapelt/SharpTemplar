using System.Text;

namespace SharpTemplar.GuidedForm.TableElements
{
    public class Table : HTMLTableElement
    {
        internal override string TagType => "table";
        internal Table(HTMLBodyElement parent, string[] _colums)
            : base(parent) { }

        internal Table(HTMLBodyElement parent)
            : base(parent) { }

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<{TagType}");
            foreach(var a in Attributes) sb.Append($" {a.Key}=\"{a.Value}\"");
            sb.Append(">");
            foreach (var td in Contains) td.ConstructElement(sb);
            sb.Append($"</{TagType}>");
        }
    }
}