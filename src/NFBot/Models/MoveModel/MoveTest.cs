using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models.MoveModel
{
    public class MoveTest
    {
        public static string Int()
        {
            MoveTest move = new MoveTest();

            move.Questions = MoveQuestion.Init();
            return JsonConvert.SerializeObject(move);
        }
        public List<MoveQuestion> Questions { get; set; }
    }
}
