using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models.CompabilityModel
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public List<AnswerModel> Answers { get; set; }
    }
}
