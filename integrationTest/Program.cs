using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();
            doc.Body.AddForm().AddLabel("First name:").AddInput().WithAttribute("type","text");

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
