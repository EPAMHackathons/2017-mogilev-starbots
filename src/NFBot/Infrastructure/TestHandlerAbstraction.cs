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
        public abstract AnswerStatus AddNewAnswer(string answer);

        public abstract string NextQuestion(out TestStatus status);

        public abstract string Analysis();

        public abstract List<string> SearchNewUsers(string code, List<TestResult> testResults);

        public abstract TestResult GetResults();
    }
}
