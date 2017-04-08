using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models.CompabilityModel
{
    public class TestDescriptionResults
    {
        public static List<TestDescriptionResults> Init()
        {
            List<TestDescriptionResults> result = new List<TestDescriptionResults>();

            result.Add(new TestDescriptionResults() { Code = "А", Description = "АГРЕССОР \n\n Вы - агрессор(преимущественно мужской тип).Сила, власть и напор, граничащие с грубостью, -вот ваш стиль в любви." });

            result.Add(new TestDescriptionResults() { Code = "Б", Description = "ИНТЕЛЛЕКТУАЛ \n\n Вы - интеллектуал (в равной степени мужской и женский тип) и склонны все оценивать с точки зрения здравого смысла." });

            result.Add(new TestDescriptionResults() { Code = "В", Description = "АЖЕРТВА \n\n Вы - жертва. 'Настоящая любовь всегда сопряжена с болью!' - так думаете вы, обрекая себя на страдания. " });

            result.Add(new TestDescriptionResults() { Code = "Г", Description = "РОМАНТИК \n\n Значит, вы - романтик. Самый важный вопрос человечества 'Быть или не быть ? ' у вас трансформируется в 'Любить или не любить ? '" });

            result.Add(new TestDescriptionResults() { Code = "Д", Description = "ЦИНИК \n\n Вы - циник (преимущественно мужской тип). Не верите в любовь ни с первого, ни со второго взгляда." });

            result.Add(new TestDescriptionResults() { Code = "", Description = "ЭГОИСТ \n\n Значит, вы - эгоист (в равной степени мужской и женский тип). Искренне верите в свою исключительность и любите не партнера, а себя в партнере." });

            return result;
        }
        
        public string Code { get; set; }

        public string Description { get; set; }
    }
}
