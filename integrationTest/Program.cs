using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();

            doc.Head.AddStyle("./test.css");
            doc.Head.AddScript("./test.js");
            doc.Head.AddScript().InsertHTMLString("console.error(\"OMG cool script\")");
            doc.Body.AddDiv().WithAttribute("class","meme").AddDiv().EnterIt().AddDiv();

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
