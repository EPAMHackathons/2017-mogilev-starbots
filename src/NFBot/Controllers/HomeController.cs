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
			if (model.Type == "confirmation")
			{
				return Ok("7c030779");
			}
			else if (model.Type == "message_new")
			{
				string message = "You said " + model.RequestObject.Body;

				var resp = new ResponseObject(message, model.RequestObject.UserId);

				await new RequestHandler().SendRequest(resp);
			}

			return Ok("ok");
		}
	}
}
