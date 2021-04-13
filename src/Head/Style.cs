using System.IO;
using SharpTemplar.Shared;

namespace SharpTemplar.HeadElements
{
    public class Style : HTMLHeadElement
    {
        internal Style(string path)
            : base("style")
        {
            Contains.Add(new HTMLString(File.ReadAllText(path)));
        }
    }
}