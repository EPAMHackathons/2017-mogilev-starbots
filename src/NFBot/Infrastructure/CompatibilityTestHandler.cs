using NFBot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFBot.Models.CompabilityModel;

namespace NFBot.Infrastructure
{
    public class CompatibilityTestHandler
    {
        public TestResultModel Result { get; private set; }

        private TestModel testModel;

        public CompatibilityTestHandler(TestResultModel result, TestModel testModel)
        {
            this.Result = result;
            this.testModel = testModel;
        }

        public TestStatus SetNewAnswer(string answer)
        {
            if (!IsValidAnswer(answer))
            {
                return TestStatus.IncorrectAnswer;
            }

            this.Result.Answers += answer;

            if (this.Result.Answers.Length== this.testModel.Questions.Count)
            {
                return TestStatus.Finished;

            }

            return TestStatus.Continue;
        }

        private bool IsValidAnswer(string answer)
        {
            string[] possibleAnswers = new string[] { "A", "B", "C", "D", "E", "F" };

            return possibleAnswers.Contains(answer.Trim().ToLower());
        }

    }
}
