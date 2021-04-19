using System.IO;
using System.Text;
using SharpTemplar.Shared;

namespace SharpTemplar
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
            if (path is not null) Contains.Add(new HTMLString(File.ReadAllText(path)));
            base.ConstructElement(sb);
        }
    }
}