using SharpTemplar;

public class Program 
{
    public static void Main()
    {
        var doc = new TemplarDocument("test");
        
        doc.Head.AddMeta().WithAttr(("chatset", "utf-8"));

        doc.Body.AddForm().Enter.AddLabel("meme", "Wauw").AddInput("text", "amazing").WithId("meme");

        Console.WriteLine(doc.GeneratePage());
    }
}