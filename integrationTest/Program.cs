using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();
            
            HTMLBodyElement d;
            doc.Body.AddDiv(out d);
            d.AddDiv().AddDiv();
            d.AddDiv();
            d.AddDiv();

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
