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
            
            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
