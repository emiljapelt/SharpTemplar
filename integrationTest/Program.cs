﻿using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();

            doc.Body.AddDiv().EnterIt().AddDiv();

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
