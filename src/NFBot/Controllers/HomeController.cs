using Microsoft.AspNetCore.Mvc;

namespace NFBot.Controllers
{
	#region Usings

	using System.Threading.Tasks;
	using NFBot.Infrastructure;
	using NFBot.Interfaces;
	using NFBot.Models;
	using NFBot.Models.DatabaseModel;

	#endregion

	public class HomeController : Controller
	{
		#region Private Fields

		private ITestManagementComponent testManagement;

		private IUserComponent userComponent;

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
			bool userExists = this.userComponent.CheckUser(model.UserId);

			if (!userExists)
			{
				this.userComponent.CreateUser(new User(model.UserId));
			}

			// Save answer for user.
			this.testManagement.SaveAnswer(model.Message);

			Test test = this.testManagement.GetCurrentTest(model.UserId);

			// Extract next question from the test
			string nextQuestion = test.TestObject;

			string message = "You said " + model.Message + nextQuestion;

			// Send answer to the user.
			var resp = new ResponseObject(message, model.UserId);

			await new RequestHandler().SendRequest(resp);

			return Ok("ok");
		}
	}
}