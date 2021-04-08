using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();
            doc.Head.AddLink("uhm", "hi").AddMeta().WithAttribute("style", "cool").AddMeta();
            doc.Body.AddForm().AddInput("text").WithAttribute("class", "meme").AddLabel("MEMES").AddBreak().AddButton("submit", "Do").ExitForm().AddAnchor("www.google.com").AddHTMLString("Google");

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
