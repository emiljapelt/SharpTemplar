using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new Document();
            doc.Body.AddParagraph("Hello World!");
            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
