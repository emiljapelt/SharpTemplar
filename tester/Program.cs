using SharpTemplar;

var doc = new TemplarDocument("test");
            
doc.Head.AddMeta().WithAttribute("charset","utf-8");

doc.Body.AddDiv().End;

doc.Body.WithAttribute("class","container");

Console.WriteLine(doc.GeneratePage());