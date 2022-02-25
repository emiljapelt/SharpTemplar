using SharpTemplar;

public class Program 
{
    public static void Main()
    {
        var doc = new TemplarDocument("test");
                    
        doc.Head.AddMeta().WithAttribute("charset","utf-8");

        doc.Body.AddDiv().End();

        doc.Body.WithAttribute("class","container");

        Console.WriteLine(doc.GeneratePage());
    }
}