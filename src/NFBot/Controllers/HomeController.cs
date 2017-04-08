using Microsoft.AspNetCore.Mvc;

namespace NFBot.Controllers
{
    #region Usings

    using System.Threading.Tasks;
    using NFBot.Infrastructure;
    using NFBot.Interfaces;
    using NFBot.Models;
    using NFBot.Models.DatabaseModel;
    using Models.CompabilityModel;
    using Models.MoveModel;

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

        static int userId = 10;

        public string Index()
        {
            //CompabilityTestHandler handler = new CompabilityTestHandler(new Test() { Code = "", TestObject = TestModel.Init(), Id = 1, Name = "знакомства" }, null);

            //handler.AddNewAnswer("A");
            //TestStatus st;
            //string results = handler.NextQuestion(out st);
            //var res = handler.GetResults();
            //handler = new CompabilityTestHandler(new Test() { Code = "", TestObject = TestModel.Init(), Id = 1, Name = "знакомства" }, res);

            //handler.AddNewAnswer("А");
            //results = handler.NextQuestion(out st);
            //var res2 = handler.GetResults();
            //handler = new CompabilityTestHandler(new Test() { Code = "", TestObject = TestModel.Init(), Id = 1, Name = "знакомства" }, res2);

            //handler.AddNewAnswer("А");
            //handler.NextQuestion(out st);
            //var res3 = handler.GetResults();
            //handler = new CompabilityTestHandler(new Test() { Code = "", TestObject = TestModel.Init(), Id = 1, Name = "знакомства" }, res3);

            //handler.AddNewAnswer("А");
            //results = handler.NextQuestion(out st);
            //var res4 = handler.GetResults();
            //handler = new CompabilityTestHandler(new Test() { Code = "", TestObject = TestModel.Init(), Id = 1, Name = "знакомства" }, res4);

            //handler.AddNewAnswer("А");
            //results = handler.NextQuestion(out st);
            //var res5 = handler.GetResults();
            //handler = new CompabilityTestHandler(new Test() { Code = "", TestObject = TestModel.Init(), Id = 1, Name = "знакомства" }, res5);

            //handler.AddNewAnswer("А");
            //results = handler.NextQuestion(out st);
            //var res6 = handler.GetResults();

            return MoveTest.Int();
        }
    }
}