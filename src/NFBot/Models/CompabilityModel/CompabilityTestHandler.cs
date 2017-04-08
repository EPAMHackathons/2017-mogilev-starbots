using NFBot.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFBot.Models.DatabaseModel;
using Newtonsoft.Json;

namespace NFBot.Models.CompabilityModel
{
    public class CompabilityTestHandler : TestHandlerAbstraction
    {
        public TestResultModel results;

        public CompabilityTestHandler(Test testModel, TestResult testResultModel) : base(testModel, testResultModel)
        {
            if (testResultModel == null)
            {
                testResultModel = new TestResult()
                {
                    IsFinished = false,
                    TestId = testModel.Id,
                    Result = null
                };
            }
        }

        public override AnswerStatus AddNewAnswer(string answer)
        {
            if (string.IsNullOrWhiteSpace(this.testResultModel.Result))
            {
                results = new TestResultModel() { Answers = "" };
                this.testResultModel = new TestResult();
                return AnswerStatus.Correct;
            }
            else
            {
                if (IsCorrect(answer))
                {
                    results = JsonConvert.DeserializeObject<TestResultModel>(this.testResultModel.Result);
                    results.Answers += answer;
                    return AnswerStatus.Correct;
                }
            }
            return AnswerStatus.Incorrect;
        }

        public override string Analysis()
        {
            throw new NotImplementedException();
        }

        public override string NextQuestion(out TestStatus status)
        {
            var test = JsonConvert.DeserializeObject<TestModel>(this.testResultModel.Result);
            if (test.Questions.Count > results.Answers.Length)
            {
                status = TestStatus.Continue;
                return test.Questions[results.Answers.Length].ToString();
            }

            if (test.Questions.Count + 1 == results.Answers.Length)
            {
                string resultCode = Analysis();
                string message = test.Description.Where(m => m.Code == resultCode.Trim().ToUpper()).FirstOrDefault().Description;
                message += "---Есть следующие комбинации. Выбери подходящую для себя.---";

                foreach (var item in test.Compare)
                {
                    if (item.Code.Contains(resultCode))
                    {
                        message += item.Description;
                    }
                }
                status = TestStatus.Continue;
                return message;
            }
            else
            {
                status = TestStatus.Finished;
                return "тест завершен";
            }
        }

        public override List<int> SearchNewUsers(List<TestResult> testResults)
        {
            return new List<int>();
        }

        public override TestResult GetResults()
        {
            testResultModel.Result = JsonConvert.SerializeObject(results);
            return testResultModel;
        }

        private bool IsCorrect(string answer)
        {
            string[] answers = new string[] { "А", "Б", "В", "Г", "Д", "Е" };

            return answers.Contains(answer.Trim().ToUpper());
        }
    }
}
