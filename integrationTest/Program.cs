using System;
using Elements;

namespace integrationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var doc = new TemplarDocument();

            
            doc.Body.BeginForm("myform")
                .AddLabel("fname","First name").AddInput("fname","text")
                .AddBreak()
                .AddLabel("lname","Last name").AddInput("lname","text")
                .AddButton("button","Submit").WithAttribute("onclick","console.log('Submitted!')").ExitForm().AddAnchor("yay").EnterIt().InsertHTMLString("s");
            
            doc.Body.AddLabel("myform", "lname", "im not in a form!!");

            System.Console.WriteLine(doc.GeneratePage());
        }
    }
}
