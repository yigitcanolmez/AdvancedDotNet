// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controllers
{
    [Controller]
    class HomeController :Controller
    {
        public HomeController()
        {

        }
        [Route("/")]
        public ContentResult Index()
        {
            return new ContentResult
            {
                Content ="Hello!",
                ContentType = "text/plain",
                StatusCode = StatusCodes.Status200OK
            };

        }

    }

}

