using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models.CompabilityModel
{
    public class TestModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public List<QuestionModel> Questions { get; set; }
    }
}
