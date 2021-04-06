using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new Document();
            doc.Body.AddParagraph("Hello World!").WithAttribute("style","color:red;");
            doc.Body.AddAnchor("www.google.com").WithAttribute("style", "color:green;").AddHTMLString("Google");
            doc.Body.AddDiv().AddHTMLString("Is a me string").AddAnchor("wikipedia.dk").AddHTMLString("Wiki");
            
            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
