using System.Text;
using System.IO;
using Elements.Shared;

namespace Elements.HeadElements
{
    public class Style : HTMLHeadElement
    {
        internal Style(string path)
        {
            tagType = "style";
            Attributes.Add("type", "text/css");
            Attributes.Add("rel", "stylesheet");
            Contains.Add(new HTMLHeadString(File.ReadAllText(path)));
        }
    }
}