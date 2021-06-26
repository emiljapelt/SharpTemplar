using System.IO;
using System.Text;

namespace SharpTemplar
{
    public class Style : HTMLHeadElement
    {
        private string path;
        internal override string TagType => "style";
        internal Style(string _path)
            : base()
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

    public abstract partial class HTMLHeadElement : HTMLElement
    {
        /// <summary>
        /// Adds Style into the Element it is called on.
        /// </summary>
        /// <returns>
        /// The Element it is called on.
        /// </returns>
        public HTMLHeadElement AddStyle(string path)
        {
            var style = new Style(path);
            AddElement(style);
            return this;
        }
    }
}