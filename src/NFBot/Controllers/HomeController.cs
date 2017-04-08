using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NFBot.Infrastructure;
using NFBot.Models;
using System.Linq;
using System.Threading.Tasks;
using NFBot.Interfaces;
using NFBot.Models.DatabaseModel;

namespace NFBot.Controllers
{
	public class HomeController : Controller
	{
		#region Private Fields

		private ITestManagementComponent testManagement;


		#endregion

		[HttpPost]
		public async Task<IActionResult> NFFEnterPoint([FromBody]RequestModel model)
		{
			// Handle only new messages.
			if (model.Type != "message_new")
			{
				return Ok("ok");
			}

			// Check whether user is exist. If not - create new.
			this.testManagement.UpdateUser(model.RequestObject.UserId);

			Test test = this.testManagement.GetCurrentTest(model.RequestObject.UserId);

			// Extract next question from the test
			string nextQuestion = test.TestObject;

			string message = "You said " + model.RequestObject.Body + nextQuestion;

			// Send answer to the user.
			var resp = new ResponseObject(message, model.RequestObject.UserId);

			await new RequestHandler().SendRequest(resp);

			return Ok("ok");
		}
	}
}