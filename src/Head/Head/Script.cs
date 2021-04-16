using System.IO;
using System.Text;

namespace SharpTemplar.HeadElements
{
    public class Script : HTMLHeadElement
    {
        private string path;
        internal Script(string _path)
            : base("script")
        {
            path = _path;
        }

        internal Script()
            : base("script") { }


        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<{TagType}>");
            sb.Append(File.ReadAllText(path));
            sb.Append($"</{TagType}>");
        }
    }
}