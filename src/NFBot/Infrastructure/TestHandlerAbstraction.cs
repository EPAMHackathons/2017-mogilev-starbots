using NFBot.Models;
using NFBot.Models.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Infrastructure
{
    public abstract class TestHandlerAbstraction
    {
        protected Test testModel;
        protected TestResult testResultModel;
        public TestHandlerAbstraction(Test testModel, TestResult testResultModel)
        {
            this.testModel = testModel;
            this.testResultModel = testResultModel;
        }

        public abstract AnswerStatus AddNewAnswer(string answer);

        public abstract string NextQuestion(out TestStatus status);

        public abstract string Analysis();

        public abstract List<int> SearchNewUsers(List<TestResult> testResults);
    }
}
