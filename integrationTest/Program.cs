using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();

            HTMLBodyElement a;
            doc.Body.AddDiv().WithAttribute("class", "outer").AddDiv().WithAttribute("class", "outer").EnterIt().AddAnchor("www.google.com", out a);

            a.InsertHTMLString("GOOGLE");

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
