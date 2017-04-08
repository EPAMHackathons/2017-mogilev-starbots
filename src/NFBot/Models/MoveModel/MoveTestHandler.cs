using NFBot.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFBot.Models.DatabaseModel;
using Newtonsoft.Json;
using NFBot.Models.Enumerations;

namespace NFBot.Models.MoveModel
{
    public class MoveTestHandler : TestHandlerAbstraction
    {
        public MoveTestResult results;
        protected Test testModel;
        protected TestResult testResultModel;
        public MoveTestHandler(Test testModel, TestResult testResultModel)
        {
            this.testModel = testModel;
            if (testResultModel == null)
            {
                this.testResultModel = new TestResult()
                {
                    IsFinished = false,
                    TestId = testModel.Id,
                    Result = null
                };
            }
            else
            {
                this.testResultModel = testResultModel;
            }
        }

        public override AnswerStatus AddNewAnswer(string answer)
        {
            if (string.IsNullOrWhiteSpace(this.testResultModel.Result))
            {
                results = new MoveTestResult() { City = null, Film = null };
                this.testResultModel.Result = JsonConvert.SerializeObject(results);
                return AnswerStatus.Correct;
            }
            else
            {
                if (IsCorrect(answer))
                {
                    results = JsonConvert.DeserializeObject<MoveTestResult>(this.testResultModel.Result);

                    if (string.IsNullOrWhiteSpace(results.City))
                    {
                        results.City = answer;
                        this.testResultModel.Result = JsonConvert.SerializeObject(results);
                    }

                    if (string.IsNullOrWhiteSpace(results.Film))
                    {
                        results.Film = answer;
                        this.testResultModel.Result = JsonConvert.SerializeObject(results);
                    }

                    return AnswerStatus.Correct;
                }
            }
            return AnswerStatus.Incorrect;
        }

        public override string Analysis()
        {
            string currentType = "";

            return currentType;
        }

        public string Analysis(MoveTestResult model)
        {
            return "";
        }

        public override string NextQuestion(out TestStatus status)
        {
            results = JsonConvert.DeserializeObject<MoveTestResult>(this.testResultModel.Result);
            var test = JsonConvert.DeserializeObject<MoveTest>(this.testModel.TestObject);
            if (string.IsNullOrWhiteSpace(results.City))
            {
                status = TestStatus.Continue;
                return test.Questions[0].Question;
            }
            else if (string.IsNullOrWhiteSpace(results.Film))
            {
                status = TestStatus.Continue;

                return test.Questions[1].Question;

            }
            else
            {
                status = TestStatus.Finished;
                return "";
            }
        }

        public override List<string> SearchNewUsers(string code, List<TestResult> testResults)
        {
            List<string> links = new List<string>();
            string linkPattern = "https://vk.com/id";

            var currentUser = JsonConvert.DeserializeObject<MoveTestResult>(testResultModel.Result);

            foreach (var item in testResults)
            {
                var selectedUser = JsonConvert.DeserializeObject<MoveTestResult>(item.Result);
                if (selectedUser.City.ToLower().Trim().Replace("-", "") == currentUser.City && selectedUser.Film.ToLower().Trim().Replace("-", "") == currentUser.Film)
                {
                    links.Add(linkPattern + item.UserId);
                }
            }

            return links;
        }

        public override TestResult GetResults()
        {
            testResultModel.Result = JsonConvert.SerializeObject(results);
            return testResultModel;
        }

        private bool IsCorrect(string answer)
        {
            return !string.IsNullOrWhiteSpace(answer);
        }
    }
}
