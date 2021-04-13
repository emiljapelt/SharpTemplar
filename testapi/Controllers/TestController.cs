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
        public IActionResult Get()
        {
            var doc = new TemplarDocument("Test site");

            doc.Head.AddStyle("./styles/minitwit.css");

            HTMLBodyElement nav;
            HTMLBodyElement body;
            HTMLListElement messages;

            doc.Body.AddDiv().WithClass("page").EnterIt()
                .AddHeader(HeaderLevel.One, "Minitwit")
                .AddDiv(out nav).WithClass("navigation")
                .AddDiv(out body).WithClass("body")
                .AddDiv().WithClass("footer").EnterIt().InsertHTMLString("Minitwit - Not A Flask Application");
            
            nav.AddAnchor("public").EnterIt().InsertHTMLString("public timeline").ToParent()
                .InsertHTMLString("|")
                .AddAnchor("sign_up").EnterIt().InsertHTMLString("sign up").ToParent()
                .InsertHTMLString("|")
                .AddAnchor("sign_in").EnterIt().InsertHTMLString("sign in");

            body.AddHeader(HeaderLevel.Two, "Public Timeline")
                .BeginUnorderedList(out messages).WithAttribute("class","messages");

            for (int i = 0; i < 10; i++)
            {
                messages.AddItem().AddStrong("Janell Gollhofer").InsertHTMLString(" When they got out into the matter with his pike, sought to restrain them.").AddSmall("- 2021-04-13 @ 20:53");
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
