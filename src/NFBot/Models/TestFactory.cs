using NFBot.Infrastructure;
using NFBot.Models.CompabilityModel;
using NFBot.Models.DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models
{
    public class TestFactory
    {
        public TestHandlerAbstraction GetTestHandler(string name, Test test, TestResult results)
        {
            if(name == "знакомство")
            {
                return new CompabilityTestHandler(test, results);
            }
            return null;
        }
    }
}
