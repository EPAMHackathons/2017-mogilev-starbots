using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NFBot.Infrastructure;
using NFBot.Models;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Controllers
{
    public class HomeController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> NFFEnterPoint([FromBody]RequestModel model)
        {
            if (model.type == "confirmation")
            {
                return Ok("7c030779");
            }
            else if (model.type == "message_new")
            {
                var userId = model.@object.UserId;
                string message = model.@object.Body.Trim().Replace(" ", "").ToLower();

                ResponseObject resp = new ResponseObject() { Message = message, UserId = userId };

                await new RequestHandler().SendRequest(resp);
            }

            return Ok("ok");
        }
    }
}
