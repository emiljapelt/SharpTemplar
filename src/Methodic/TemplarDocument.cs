using System.Text;

namespace SharpTemplar.Methodic;

public class TemplarDocument
{
    public Head Head { get; }
    public Body Body { get; }

    public TemplarDocument(string title)
    {
        Head = new Head(title);
        Body = new Body();
    }


    public override string ToString()
    {
        return GeneratePage();
    }

    public string GeneratePage()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<!DOCTYPE html>");
        sb.Append("<html>");
        Head.ConstructElement(sb);
        Body.ConstructElement(sb);
        sb.Append("</html>");
        return sb.ToString();
    }
}