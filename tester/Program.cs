using SharpTemplar;

var doc = new TemplarDocument("tester");
doc.Body.AddParagraph("hi");

Console.WriteLine(doc.GeneratePage());