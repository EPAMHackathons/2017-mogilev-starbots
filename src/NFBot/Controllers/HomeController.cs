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
    using Infrastructure.DBComponents;
    using System.Linq;

    #endregion

    public class HomeController : Controller
    {
        #region Private Fields

        private ITestManagementComponent testManagement = new TestComponent();

        private IUserComponent userComponent = new UserComponent();

		private TestResultComponent testResultComponent = new TestResultComponent();

		#endregion

        [HttpPost]
        public async Task<IActionResult> NFFEnterPoint([FromBody]RequestModel model)
        {
            //RequestModel model = new RequestModel
            //{
            //	RequestObject = new RequestObject
            //	{
            //		Body = "hello",
            //		UserId = 1
            //	},
            //	Type = "message_new"
            //};

            // Handle only new messages.
            try
            {

           
            if (model.Type != "message_new")
            {
                return Ok("ok");
            }

            this.CheckUser(model);

            // Save answer for user.
            //this.testManagement.SaveAnswer(model.Message);
            string nextQuestion = null;
            TestStatus newStatus;

            Test test = this.testManagement.GetCurrentTest(model.UserId);

            if (test == null)
            {
                Test testByCode = this.testManagement.GetTestByCode(model.Message);
                if (testByCode == null)
                {
                    nextQuestion = MessagesConstants.Introduction;
                    var tests = this.testManagement.GetAllTests();

                    nextQuestion += string.Join("\n", tests.Select(t => t.Code));

                }
                else
                {
                    this.userComponent.SetupCurrentTest(model.UserId, testByCode.Id);

					TestHandlerAbstraction handler = TestFactory.GetTestHandler(model.Message, testByCode, null);
						handler.AddNewAnswer(model.Message);
                        testResultComponent.SaveResult(model.UserId, handler.GetResults());
                        nextQuestion = handler.NextQuestion(out newStatus);
				}
			}
			else
			{
					nextQuestion = this.GetNextQuestion(test, model.Message, model.UserId);
				}



                // Extract next question from the test
                //string nextQuestion = test.TestObject;

                //string message = nextQuestion;

                // Send answer to the user.
                if (nextQuestion.Length < 500) {
                    var resp = new ResponseObject(nextQuestion, model.UserId);

                    new RequestHandler().SendRequest(resp);
                }
                else {
                    int itemsCount = nextQuestion.Length / 500;
                    for (int i = 0; i < itemsCount; i++)
                    {
                        var resp1 = new ResponseObject(nextQuestion.Substring(i * 500, 500), model.UserId);

                        new RequestHandler().SendRequest(resp1);
                    }

                    var resp = new ResponseObject(nextQuestion.Substring((itemsCount) * 500), model.UserId);

                    new RequestHandler().SendRequest(resp);
                }
            }
            catch (System.Exception te)
            {
                string ee = te.Message;
            }
            return Ok("ok");
        }

		private string GetNextQuestion(Test test, string message, int userId)
		{
			string result = string.Empty;
			TestStatus status = TestStatus.Continue;

            var res = testResultComponent.GetCurrentUserResult(userId);

            var handler = TestFactory.GetTestHandler(test.Code, test, res);

            bool isCotrrect = handler.AddNewAnswer(message) == Models.Enumerations.AnswerStatus.Correct;
            if (isCotrrect)
            {
                this.testResultComponent.SaveResult(userId, handler.GetResults());

                result = handler.NextQuestion(out status);
            }
            else{
                result = MessagesConstants.IncorrectAnswer;
            }

            if(status == TestStatus.Finished)
            {
                var userResults = testResultComponent.GetAllResults(test.Id);
                result = string.Join("\n",handler.SearchNewUsers(result, userResults));
                this.userComponent.SetupCurrentTest(userId, 0);
            }

            //switch (test.Status)
            //{
            //	case TestStatus.Finished:
            //		{
            //			//var handler = new CompabilityTestHandler(test, null);

            //                     //var analysisResult = handler.SearchNewUsers();

            //			break;
            //		}
            //	case TestStatus.Continue:

            //                 break;
            //             case TestStatus.IncorrectAnswer:
            //                 result = "Incorrect answer - please try again.";
            //                 break;
            //             default:
            //                 break;
            //         }

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