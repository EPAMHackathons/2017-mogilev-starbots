using NFBot.Infrastructure;
using NFBot.Models.CompabilityModel;
using NFBot.Models.DatabaseModel;
using NFBot.Models.MoveModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models
{
    public static class TestFactory
    {
        public static TestHandlerAbstraction GetTestHandler(string name, Test test, TestResult results)
        {
            if(name == "знакомства")
            {
                return new CompabilityTestHandler(test, results);
            }

            if (name == "кино")
            {
                return new MoveTestHandler(test, results);
            } 

            return null;
        }
    }
}
