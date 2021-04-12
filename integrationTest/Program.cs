using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();

            
            doc.Body.BeginTable("Id", "Name").WithAttribute("meme","great").AddTableRow("1", "Emil").WithAttribute("very", "cool").ExitTable().WithAttribute("uhm","hi").AddButton("submit", "HEJ");

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
