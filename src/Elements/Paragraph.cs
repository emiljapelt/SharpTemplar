
namespace Elements
{
    public class Paragraph : HTMLElement
    {
        public string Content { get; set; }
        internal Paragraph(string content)
        {
            ElementTag = "p";
            Content = content;
        }
    }
}