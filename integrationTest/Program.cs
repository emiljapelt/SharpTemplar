using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();
            doc.Body.AddParagraph("Hello World!").WithClass("meme");
            doc.Body.AddAnchor("www.google.com").AddHTMLString("Google");
            doc.Body.AddDiv().AddHTMLString("Is a me string").AddAnchor("wikipedia.dk").AddHTMLString("Wiki");

            doc.Head.AddStyleSheet("./test.css");

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
