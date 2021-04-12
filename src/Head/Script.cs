using System.Text;
using System.IO;
using Elements.Shared;

namespace Elements.HeadElements
{
    public class Script : HTMLHeadElement
    {
        internal Script(string path)
            : base("scritp")
        {
            Contains.Add(new HTMLString(File.ReadAllText(path)));
        }

        internal Script()
            : base("script") { }
    }
}