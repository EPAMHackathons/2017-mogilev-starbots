using NFBot.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NFBot.Models.DatabaseModel;

namespace NFBot.Models.CompabilityModel
{
    public class CompabilityTestHandler : TestHandlerAbstraction
    {
        public CompabilityTestHandler(Test testModel, TestResult testResultModel): base(testModel, testResultModel)
        {

        }

        public override AnswerStatus AddNewAnswer(string answer)
        {
            throw new NotImplementedException();
        }

        public override string Analysis()
        {
            throw new NotImplementedException();
        }

        public override string NextQuestion(out TestStatus status)
        {
            throw new NotImplementedException();
        }

        public override List<int> SearchNewUsers(List<TestResult> testResults)
        {
            throw new NotImplementedException();
        }
    }
}
