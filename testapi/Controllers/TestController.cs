using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpTemplar;

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
            var doc = new TemplarDocument("Minitwit");

            doc.Body.BeginUnorderedList().WithAttribute("cool","stats")
                .AddItem().InsertHTMLString("wow")
                .Exit().AddDiv();

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 200,
                Content = doc.GeneratePage()
            };
        }

        [HttpGet("minitwit")]
        public IActionResult GetMinitwit()
        {
            var doc = new TemplarDocument("Minitwit");

            doc.Head.AddStyle("./styles/minitwit.css");

            HTMLBodyElement nav;
            HTMLBodyElement body;
            HTMLListElement messages;

            doc.Body.AddDiv().WithClass("page").EnterIt()
                .AddHeader(HeaderLevel.One, "Minitwit")
                .AddDiv(out nav).WithClass("navigation")
                .AddDiv(out body).WithClass("body")
                .AddDiv().WithClass("footer").EnterIt().InsertHTMLString("Minitwit - Not A Flask Application");
            
            nav.AddAnchor("public").EnterIt().InsertHTMLString("public timeline").Exit()
                .InsertHTMLString("|")
                .AddAnchor("sign_up").EnterIt().InsertHTMLString("sign up").Exit()
                .InsertHTMLString("|")
                .AddAnchor("sign_in").EnterIt().InsertHTMLString("sign in");

            body.AddHeader(HeaderLevel.Two, "Public Timeline")
                .BeginUnorderedList(out messages).WithAttribute("class","messages");

            for (int i = 0; i < 10; i++)
            {
                messages.AddItem().AddStrong().EnterIt().AddAnchor("deadend").EnterIt().InsertHTMLString("Janell Gollhofer ").Exit().Exit().InsertHTMLString("When they got out into the matter with his pike, sought to restrain them.").AddSmall("- 2021-04-13 @ 20:53");
            }

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 200,
                Content = doc.GeneratePage()
            };
        }
    }
}
