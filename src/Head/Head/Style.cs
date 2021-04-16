using System.IO;
using System.Text;

namespace SharpTemplar.HeadElements
{
    public class Style : HTMLHeadElement
    {
        private string path;
        internal Style(string _path)
            : base("style")
        {
            path = _path;
        }

        internal override void ConstructElement(StringBuilder sb)
        {
            sb.Append($"<{TagType}>");
            sb.Append(File.ReadAllText(path));
            sb.Append($"</{TagType}>");
        }
    }
}