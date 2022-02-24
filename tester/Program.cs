using SharpTemplar;

var doc = new TemplarDocument("test");
            
doc.Head.AddMeta().WithAttribute("charset","utf-8");

int i = 0;
doc.Body.While(() => i < 2, () => i++)
            .AddParagraph("1")
        .Exit
        .AddParagraph("2");

Console.WriteLine(doc.GeneratePage());