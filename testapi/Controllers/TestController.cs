﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
// using SharpTemplar.GuidedForm;
using SharpTemplar.FreeForm;
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
            
            doc.Head.AddScript().InjectHTMLString("console.error('yike')");

            doc.Body.InjectHTMLString("inner");
            

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 200,
                Content = doc.GeneratePage()
            };
        }

        private (FreeFormDocument doc, HTMLBodyElement bdy) GenerateMinitwitBaseDocument()
        {
            var doc = new FreeFormDocument("Minitwit");

            doc.Head.AddStyle("./styles/minitwit.css");

            HTMLBodyElement nav;
            HTMLBodyElement body;

            doc.Body.AddDiv().WithClass("page").EnterIt()
                .AddHeader(HeaderLevel.One, "Minitwit")
                .AddDiv(out nav).WithClass("navigation")
                .AddDiv(out body).WithClass("body")
                .AddDiv().WithClass("footer").EnterIt().AddHTMLString("Minitwit - Not A Flask Application");
            
            nav.AddAnchor("/minitwit").EnterIt().AddHTMLString("public timeline").Exit()
                .AddHTMLString("|")
                .AddAnchor("/minitwit/sign_up").EnterIt().AddHTMLString("sign up").Exit()
                .AddHTMLString("|")
                .AddAnchor("deadend").EnterIt().AddHTMLString("sign in");

            return (doc, body);
        }

        [HttpGet("minitwit")]
        public IActionResult GetMinitwit()
        {
            var (doc, body) = GenerateMinitwitBaseDocument();

            HTMLBodyElement messages;

            body.AddHeader(HeaderLevel.Two, "Public Timeline")
                .AddUnorderedList(out messages).WithAttribute("class","messages");

            for (int i = 0; i < 10; i++)
            {
                HTMLBodyElement item;
                messages.AddListItem(out item);
                item.AddImage("https://www.gravatar.com/avatar/2a848aee6300789fe1f741b589572a98?d=identicon&s=48")
                    .AddParagraph().EnterIt()
                        .AddStrong().EnterIt()
                            .AddAnchor("deadend").EnterIt().AddHTMLString("Leatha Duncker").Exit().AddHTMLString(" ").Exit()
                        .AddHTMLString("Perhaps you can take it for an instant.")
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
