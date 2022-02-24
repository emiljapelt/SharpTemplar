using SharpTemplar;

var doc = new TemplarDocument("tester");
doc.Body.AddTextArea(10, null).InjectHTMLString("Omg hej");

Console.WriteLine(doc.GeneratePage());