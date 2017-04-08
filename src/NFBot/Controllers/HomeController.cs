﻿using Microsoft.AspNetCore.Mvc;

namespace NFBot.Controllers
{
	#region Usings

	using System.Threading.Tasks;
	using NFBot.Infrastructure;
	using NFBot.Interfaces;
	using NFBot.Models;
	using NFBot.Models.DatabaseModel;
	using Models.CompabilityModel;
	using Infrastructure.DBComponents;
	using System.Linq;

	#endregion

	public class HomeController : Controller
	{
		#region Private Fields

		private ITestManagementComponent testManagement = new TestComponent();

		private IUserComponent userComponent = new UserComponent();

		#endregion

		//[HttpPost]
		public async Task<IActionResult> NFFEnterPoint(/*[FromBody]RequestModel model*/)
		{
			RequestModel model = new RequestModel
			{
				RequestObject = new RequestObject
				{
					Body = "знакомства",
					UserId = 1
				},
				Type = "message_new"
			};

			// Handle only new messages.
			if (model.Type != "message_new")
			{
				return Ok("ok");
			}

			this.CheckUser(model);

			// Save answer for user.
			//this.testManagement.SaveAnswer(model.Message);
			string nextQuestion = null;

			Test test = this.testManagement.GetCurrentTest(model.UserId);

			if (test == null)
			{
				var tests = this.testManagement.GetAllTests();

				nextQuestion = string.Join("\n", tests.Select(t => t.Code));
			}
			else
			{
				nextQuestion = this.GetNextQuestion(test.Status);
			}
			TestStatus newStatus;

			

			// Extract next question from the test
			//string nextQuestion = test.TestObject;

			//string message = nextQuestion;

			// Send answer to the user.
			var resp = new ResponseObject(nextQuestion, model.UserId);

			await new RequestHandler().SendRequest(resp);

			return Ok("ok");
		}

		private string GetNextQuestion(TestStatus status)
		{
			string result  = string.Empty;

			switch (status)
			{
				//case TestStatus.Undefined:
				//	{
				//		Test newTest = this.testManagement.GetTestByCode(model.Message);

				//		if (newTest == null)
				//		{
				//			nextQuestion = "Incorrect choice. Please, try again.";
				//		}
				//		else
				//		{
				//			var handler = new Models.TestFactory().GetTestHandler(model.Message, newTest, null);

				//			nextQuestion = handler.NextQuestion(out newStatus);
				//		}

				//		//Test newTest = new Test { Code = model.Message, TestObject = TestModel.Init() };

				//		//var handler = new CompabilityTestHandler(newTest, null);
				//		//handler.AddNewAnswer(model.Message);

				//		//this.userComponent.SetupCurrentTest(model.UserId, test.Id);

				//		//nextQuestion = handler.NextQuestion(out newStatus);
				//		break;
				//	}
				case TestStatus.Finished:
					{
						//var handler = new CompabilityTestHandler(test, null);

						//var analysisResult = handler.SearchNewUsers();

						break;
					}
				case TestStatus.Continue:

					break;
				case TestStatus.IncorrectAnswer:
					result = "Incorrect answer - please try again.";
					break;
				default:
					break;
			}

			return result;
		}

		private void CheckUser(RequestModel model)
		{
			// Check whether user is exist. If not - create new.
			bool userExists = this.userComponent.CheckUser(model.UserId);

			if (!userExists)
			{
				this.userComponent.CreateUser(new User(model.UserId));
			}
		}

		static int userId = 10;


		private string Index()
		{
			CompabilityTestHandler handler = new CompabilityTestHandler(new Test() { Code = "", TestObject = TestModel.Init(), Id = 1, Name = "знакомства" }, null);

			handler.AddNewAnswer("A");
			TestStatus st;
			string results = handler.NextQuestion(out st);
			var res = handler.GetResults();
			handler = new CompabilityTestHandler(new Test() { Code = "", TestObject = TestModel.Init(), Id = 1, Name = "знакомства" }, res);

			handler.AddNewAnswer("А");
			results = handler.NextQuestion(out st);
			var res2 = handler.GetResults();
			handler = new CompabilityTestHandler(new Test() { Code = "", TestObject = TestModel.Init(), Id = 1, Name = "знакомства" }, res2);

			handler.AddNewAnswer("А");
			handler.NextQuestion(out st);
			var res3 = handler.GetResults();
			handler = new CompabilityTestHandler(new Test() { Code = "", TestObject = TestModel.Init(), Id = 1, Name = "знакомства" }, res3);

			handler.AddNewAnswer("А");
			results = handler.NextQuestion(out st);
			var res4 = handler.GetResults();
			handler = new CompabilityTestHandler(new Test() { Code = "", TestObject = TestModel.Init(), Id = 1, Name = "знакомства" }, res4);

			handler.AddNewAnswer("А");
			results = handler.NextQuestion(out st);
			var res5 = handler.GetResults();
			handler = new CompabilityTestHandler(new Test() { Code = "", TestObject = TestModel.Init(), Id = 1, Name = "знакомства" }, res5);

			handler.AddNewAnswer("А");
			results = handler.NextQuestion(out st);
			var res6 = handler.GetResults();

			return "Complete0;";
		}
	}
}