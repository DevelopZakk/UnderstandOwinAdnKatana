using System.Web.Http;

namespace UnderstandOwinAndKatana.Controllers
{
    [RoutePrefix("api")]
    public class HelloWorldApiController:ApiController
    {
        [Route("hello")]
        [HttpGet]
        public IHttpActionResult HelloWorld()
        {
            return Content(System.Net.HttpStatusCode.OK, "Hello from Web Api");
        }
        
    }
}