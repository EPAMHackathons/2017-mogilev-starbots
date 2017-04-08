using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models.MoveModel
{
    public class MoveQuestion
    {
        public static List<MoveQuestion> Init()
        {
            List<MoveQuestion> questions = new List<MoveQuestion>();

            questions.Add(new MoveQuestion() { Question = "Какой город?" });
            questions.Add(new MoveQuestion() { Question = "Название фильма" });

            return questions;
        }

        public string Question { get; set; }
    }
}
