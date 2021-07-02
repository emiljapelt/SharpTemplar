using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
// using SharpTemplar.GuidedForm;
using SharpTemplar.FreeForm;
using SharpTemplar;
using static SharpTemplar.HTMLEvent;

namespace testapi.Controllers
{
    [ApiController]
    [Route("/")]
    public class TestSiteController : ControllerBase
    {

        public TestSiteController() { }

        [HttpGet]
        public IActionResult GetTestSite()
        {
            var doc = new FreeFormDocument("test");
            
            doc.Head.AddMeta().WithAttribute("charset","utf-8");
            doc.Head.AddScript("./scripts/test.js");

            doc.Body.AddButton("button","click me!").OnEvent(click, "test1");
            doc.Body.AddButton("button","click me too!").OnEvent(click, "test2", "'hi'");

            System.Console.WriteLine(doc);

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 200,
                Content = doc.GeneratePage()
            };
        }
    }
}
