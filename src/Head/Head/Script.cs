using System.IO;
using System.Text;

namespace SharpTemplar.HeadElements
{
    public class Script : HTMLHeadElement
    {
        private string path;
        internal override string TagType => "script";
        internal Script(string _path)
            : base()
        {
            path = _path;
        }

        internal Script()
            : base() { }


        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<{TagType}>");
            if (path is not null) sb.Append(File.ReadAllText(path));
            sb.Append($"</{TagType}>");
        }
    }
}