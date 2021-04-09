using System.Text;
using System.IO;
using Elements.Shared;

namespace Elements.HeadElements
{
    public class Script : HTMLHeadElement
    {
        internal Script(string path)
        {
            tagType = "script";
            Contains.Add(new HTMLHeadString(File.ReadAllText(path)));
        }

        internal Script()
        {
            tagType = "script";
        }
    }
}