using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();

            doc.Head.AddStyle("./test.css").AddMeta().WithAttribute("class","headers").AddScript();
            doc.Body.EnterIt();

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
