using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();

            
            doc.Body.BeginTable().WithAttribute("is","table")
                .BeginRow().WithAttribute("is","row")
                    .AddHead("Id").WithAttribute("is","head")
                    .AddHead("Name").WithAttribute("is","head").ExitRow()
                .BeginRow()
                    .AddData("553")
                    .AddData("Emil").WithAttribute("is","cool").ExitRow()
                .ExitTable();

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
