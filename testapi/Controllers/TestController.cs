using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharpTemplar.GuidedForm;
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
            var doc = new FreeFormDocument("Minitwit");
            
            doc.Head.AddScript();

            doc.Body.AddParagraph().EnterIt().AddSmall().AddBreak().AddStrong();
            

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 200,
                Content = doc.GeneratePage()
            };
        }

        private (TemplarDocument doc, HTMLBodyElement bdy) GenerateMinitwitBaseDocument()
        {
            var doc = new GuidedFormDocument("Minitwit");

            doc.Head.AddStyle("./styles/minitwit.css");

            HTMLBodyElement nav;
            HTMLBodyElement body;

            doc.Body.AddDiv().WithClass("page").EnterIt()
                .AddHeader(HeaderLevel.One, "Minitwit")
                .AddDiv(out nav).WithClass("navigation")
                .AddDiv(out body).WithClass("body")
                .AddDiv().WithClass("footer").EnterIt().InsertHTMLString("Minitwit - Not A Flask Application");
            
            nav.AddAnchor("/minitwit").EnterIt().InsertHTMLString("public timeline").Exit()
                .InsertHTMLString("|")
                .AddAnchor("/minitwit/sign_up").EnterIt().InsertHTMLString("sign up").Exit()
                .InsertHTMLString("|")
                .AddAnchor("deadend").EnterIt().InsertHTMLString("sign in");

            return (doc, body);
        }

        [HttpGet("minitwit")]
        public IActionResult GetMinitwit()
        {
            var (doc, body) = GenerateMinitwitBaseDocument();

            HTMLListElement messages;

            body.AddHeader(HeaderLevel.Two, "Public Timeline")
                .BeginUnorderedList(out messages).WithAttribute("class","messages");

            for (int i = 0; i < 10; i++)
            {
                HTMLBodyElement item;
                messages.AddItem(out item);
                item.AddImage("https://www.gravatar.com/avatar/2a848aee6300789fe1f741b589572a98?d=identicon&s=48")
                    .AddParagraph().EnterIt()
                        .AddStrong().EnterIt()
                            .AddAnchor("deadend").EnterIt().InsertHTMLString("Leatha Duncker").Exit().InsertHTMLString(" ").Exit()
                        .InsertHTMLString("Perhaps you can take it for an instant.")
                        .AddSmall(" - 2021-04-15 @ 14:11");
            }

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 200,
                Content = doc.GeneratePage()
            };
        }

        [HttpGet("minitwit/sign_up")]
        public IActionResult GetMinitwitSignUp()
        {
            var (doc, body) = GenerateMinitwitBaseDocument();

            body.AddHeader(HeaderLevel.Two, "Sign Up");

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 200,
                Content = doc.GeneratePage()
            };
        }
    }
}
