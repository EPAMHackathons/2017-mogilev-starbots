using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models.CompabilityModel
{
    public class TestModel
    {
        public static string Init()
        {
            TestModel model = new TestModel();
            model.Name = "знакомства";
            model.Questions = QuestionModel.Init();
            model.Description = TestDescriptionResults.Init();
            model.Compare = CompareTable.Init();
            return JsonConvert.SerializeObject(model);
        }

        public string Name { get; set; }

        public List<QuestionModel> Questions { get; set; }

        public List<TestDescriptionResults> Description { get; set; }

        public List<CompareTable> Compare { get; set; }
    }
}
