using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();
            doc.Head.AddScript("./test.js");
            doc.Body.AddForm().AddInput("text").WithAttribute("class", "meme").AddLabel("MEMES").AddBreak().AddButton("submit", "Do").ExitForm().AddAnchor("www.google.com").AddHTMLString("Google");

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
