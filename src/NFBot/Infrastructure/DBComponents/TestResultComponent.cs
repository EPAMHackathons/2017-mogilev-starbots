using NFBot.Models.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Infrastructure.DBComponents
{
    public class TestResultComponent
    {
        public TestResult GetUserResult(int userId, int testId)
        {
            return null;
        }

        public TestResult GetCurrentUserResult(int userId)
        {
            return null;
        }

        public void SaveResult(int userId, int testId, TestResult results)
        {

        }

        public List<TestResult> GetAllResults(int testId)
        {
            return null;
        }
    }
}
