
namespace Elements
{
    public class Paragraph : HTMLElement
    {
        public string Content { get; set; }
        public Paragraph(string content)
        {
            ElementTag = "p";
            Content = content;
        }
    }
}