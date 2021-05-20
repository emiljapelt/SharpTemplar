using System;
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
            
            doc.Body.AddForm("form1").EnterIt()
                .AddSelect("car").EnterIt()
                    .AddOption("volve","Volvo")
                    .AddOption("ford").InjectHTMLString("Ford");

            return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = 200,
                Content = doc.GeneratePage()
            };
        }
    }
}
