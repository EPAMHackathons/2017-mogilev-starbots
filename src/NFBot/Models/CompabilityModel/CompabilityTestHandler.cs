using NFBot.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFBot.Models.DatabaseModel;
using Newtonsoft.Json;
using NFBot.Models.Enumerations;

namespace NFBot.Models.CompabilityModel
{
	public class CompabilityTestHandler : TestHandlerAbstraction
	{
		public TestResultModel results;
		protected Test testModel;
		protected TestResult testResultModel;
		public CompabilityTestHandler(Test testModel, TestResult testResultModel)
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
				results = new TestResultModel() { Answers = "" };
				this.testResultModel.Result = JsonConvert.SerializeObject(results);
				return AnswerStatus.Correct;
			}
			else
			{
				if (IsCorrect(answer))
				{
					results = JsonConvert.DeserializeObject<TestResultModel>(this.testResultModel.Result);
					results.Answers += answer;
					this.testResultModel.Result = JsonConvert.SerializeObject(results);
					return AnswerStatus.Correct;
				}
			}
			return AnswerStatus.Incorrect;
		}

		public override string Analysis()
		{
			string currentType = "";
			int maxValue = 0;
			string[] answers = new string[] { "А", "Б", "В", "Г", "Д", "Е" };
			foreach (string item in answers)
			{
				int i = results.Answers.ToUpper().Where(m => m == item.ToUpper()[0]).Count();

				if (i > maxValue)
				{
					maxValue = i;
					currentType = item;
				}
			}

			return currentType;
		}

		public string Analysis(TestResultModel model)
		{
			string currentType = "";
			int maxValue = 0;
			string[] answers = new string[] { "А", "Б", "В", "Г", "Д", "Е" };
			foreach (var item in answers)
			{
				int i = model.Answers.ToUpper().Where(m => m == item.ToUpper()[0]).Count();

				if (i > maxValue)
				{
					maxValue = i;
					currentType = item;
				}
			}

			return currentType;
		}

		public override string NextQuestion(out TestStatus status)
		{
			results = JsonConvert.DeserializeObject<TestResultModel>(this.testResultModel.Result);
			var test = JsonConvert.DeserializeObject<TestModel>(this.testModel.TestObject);
			if (test.Questions.Count > results.Answers.Length)
			{
				status = TestStatus.Continue;
				return test.Questions[results.Answers.Length].ToString();
			}

			if (test.Questions.Count == results.Answers.Length)
			{
				string resultCode = Analysis();
				string message = test.Description.Where(m => m.Code == resultCode).FirstOrDefault().Description;
				message += "\n ---Есть следующие комбинации. Выбери подходящую для себя.--- \n\n\n";
				int index = 0;
				string[] answers = new string[] { "А", "Б", "В", "Г", "Д", "Е" };
				foreach (var item in test.Compare)
				{
					if (item.Code.Contains(resultCode))
					{
						message += answers[index] + ") " + item.Description + "\n\n";
						index++;
					}
				}
				status = TestStatus.Continue;
				return message;
			}
			else
			{
				status = TestStatus.Finished;
				return results.Answers.Last().ToString();
			}
		}

		public override List<string> SearchNewUsers(string code, List<TestResult> testResults)
		{
			List<string> links = new List<string>();
			string linkPattern = "https://vk.com/id";
			foreach (var item in testResults)
			{
				if (Analysis(JsonConvert.DeserializeObject<TestResultModel>(item.Result)) == code)
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
			string[] answers = new string[] { "А", "Б", "В", "Г", "Д", "Е" };

			return answers.Any(m => m == answer.Trim().ToUpper());
		}
	}
}
