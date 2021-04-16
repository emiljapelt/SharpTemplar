using System.IO;
using SharpTemplar.Shared;

namespace SharpTemplar.HeadElements
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