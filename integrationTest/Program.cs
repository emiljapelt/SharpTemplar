using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();

            
            doc.Body.BeginTable().WithAttribute("is","table").BeginRow().WithAttribute("is","row").AddHead("Id").WithAttribute("is","head").AddData("2").WithAttribute("is","data").ExitRow().ExitTable();

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
