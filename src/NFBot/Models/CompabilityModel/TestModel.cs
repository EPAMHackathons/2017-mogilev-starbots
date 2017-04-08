using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models.CompabilityModel
{
    public class TestModel
    {
        public static TestModel Init()
        {
            TestModel model = new TestModel();
            model.Name = "знакомства";
            model.Questions = QuestionModel.Init();
            return model;
        }

        public string Name { get; set; }

        public List<QuestionModel> Questions { get; set; }
    }
}
