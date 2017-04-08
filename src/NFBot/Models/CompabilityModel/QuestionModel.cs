using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models.CompabilityModel
{
    public class QuestionModel
    {
        public static List<QuestionModel> Init()
        {
            List<AnswerModel> answers1 = new List<AnswerModel>();
            answers1.Add(new AnswerModel() { Code = "А", Value= "вижу цель, не вижу препятствий! \n" });
            answers1.Add(new AnswerModel() { Code = "Б", Value= "комфортное и эмоционально насыщеное сосуществование двух индивидуумов; \n" });
            answers1.Add(new AnswerModel() { Code = "В", Value= "способность полностью раствориться в любимом человеке; \n" });
            answers1.Add(new AnswerModel() { Code = "Г", Value= "глоток живительной влаги в пустыне обыденности; \n" });
            answers1.Add(new AnswerModel() { Code = "Д", Value= "физическое состояние, вызванное биохимическими процессами; \n" });
            answers1.Add(new AnswerModel() { Code = "Е", Value= "когда один дает, а другой пользуется. \n" });
            List<AnswerModel> answers2 = new List<AnswerModel>();
            answers2.Add(new AnswerModel() { Code = "А", Value = "спички и топор; \n" });
            answers2.Add(new AnswerModel() { Code = "Б", Value = "линзу и несколько зерен пшеницы; \n" });
            answers2.Add(new AnswerModel() { Code = "В", Value = "пляжный зонтик; \n" });
            answers2.Add(new AnswerModel() { Code = "Г", Value = "томик любимых стихов; \n" });
            answers2.Add(new AnswerModel() { Code = "Д", Value = "5 кг тротила, чтобы устроить грандиозную рыбалку; \n" });
            answers2.Add(new AnswerModel() { Code = "Е", Value = "мобильный телефон системы Global Star. \n" });
            List<AnswerModel> answers3 = new List<AnswerModel>();
            answers3.Add(new AnswerModel() { Code = "А", Value = "на их свадьбе отравленное вино лилось бы рекой \n" });
            answers3.Add(new AnswerModel() { Code = "Б", Value = "здравый смысл восторжествовал бы над многолетней враждой; \n" });
            answers3.Add(new AnswerModel() { Code = "В", Value = "над влюбленными супругами довлело бы родительское проклятие; \n" });
            answers3.Add(new AnswerModel() { Code = "Г", Value = "любовь и нежность победили бы все предрассудки; \n" });
            answers3.Add(new AnswerModel() { Code = "Д", Value = "Шекспир остался бы в памяти современников как никчемный бумагомарака; \n" });
            answers3.Add(new AnswerModel() { Code = "Е", Value = "они родили бы детей и жили в мире-согласии до глубокой старости. \n" });
            List<AnswerModel> answers4 = new List<AnswerModel>();
            answers4.Add(new AnswerModel() { Code = "А", Value = "фантастический роман Айзека Азимова \n" });
            answers4.Add(new AnswerModel() { Code = "Б", Value = "'Скотный двор' Оруэлла; \n" });
            answers4.Add(new AnswerModel() { Code = "В", Value = "Энциклопедию нетрадиционной медицины; \n" });
            answers4.Add(new AnswerModel() { Code = "Г", Value = "'Унесенные ветром' Маргарет Митчелл; \n" });
            answers4.Add(new AnswerModel() { Code = "Д", Value = "телефонный справочник; \n" });
            answers4.Add(new AnswerModel() { Code = "Е", Value = "'Милый друг' Мопассана. \n" });
            //List<AnswerModel> answers5 = new List<AnswerModel>();
            //List<AnswerModel> answers6 = new List<AnswerModel>();
            //List<AnswerModel> answers7 = new List<AnswerModel>();
            //List<AnswerModel> answers8 = new List<AnswerModel>();
            //List<AnswerModel> answers9 = new List<AnswerModel>();
            //List<AnswerModel> answers10 = new List<AnswerModel>();
            //List<AnswerModel> answers11 = new List<AnswerModel>();
            //List<AnswerModel> answers12 = new List<AnswerModel>();
            //List<AnswerModel> answers13 = new List<AnswerModel>();
            //List<AnswerModel> answers14 = new List<AnswerModel>();
            //List<AnswerModel> answers15 = new List<AnswerModel>();
            //List<AnswerModel> answers16 = new List<AnswerModel>();

            List<QuestionModel> questions = new List<QuestionModel>();

            questions.Add(new QuestionModel() { Question = "1. Настоящая любовь - это... \n \n", Answers = answers1 });
            questions.Add(new QuestionModel() { Question = "2. Вы возьмете с собой на необитаемый остров...  \n \n", Answers = answers2 });
            questions.Add(new QuestionModel() { Question = "3. Если бы Ромео и Джульета остались живы и сочетались бы браком, то...  \n \n", Answers = answers3 });
            questions.Add(new QuestionModel() { Question = "4. Какую из этих книг вы отнесли бы в разряд любимых? \n \n", Answers = answers4 });
            //questions.Add(new QuestionModel() { Question = "5. Представьте, что вы стали свидетелем такой сцены: молодой человек, отчаянно жестикулируя, что-то бурно объясняет своей спутнице, повернувшись к ней всем корпусом, а та слушает его с закрытыми глазами. Вы не слышите их разговор, но жизненный опыт подсказывает вам, что он говорит ей:" });
            //questions.Add(new QuestionModel() { Question = "6. А она в это время думает..." });
            //questions.Add(new QuestionModel() { Question = "7. Ваш любимый цвет -" });
            //questions.Add(new QuestionModel() { Question = "8. Представьте себе такую ситуацию: вы оба очень голодны, но единственная еда в доме - одинокий пирожок. Как вы поступите?" });
            //questions.Add(new QuestionModel() { Question = "9. Вы узнали, что у вашего любимого есть любовник(ца). Ваша реакция..." });
            //questions.Add(new QuestionModel() { Question = "10. Глядя на фотографию сексуальной дамы в роскошном неглиже, вы думаете..." });
            //questions.Add(new QuestionModel() { Question = "11. Ваша знакомая пара разошлась, при этом муж оставил все имущество жене. Ваша реакция..." });
            //questions.Add(new QuestionModel() { Question = "12. Лучше секса может быть только..." });
            //questions.Add(new QuestionModel() { Question = "13. Коррида - это.." });
            //questions.Add(new QuestionModel() { Question = "14. Ради любимого человека вы готовы..." });
            //questions.Add(new QuestionModel() { Question = "15. Представьте такую ситуацию: ваши отношения терпят крах, и вторая половина недвусмысленно дает понять, что пора ставить точку. Как вы поступите?" });
            //questions.Add(new QuestionModel() { Question = "16. Лучший эротический подарок любимого - это..." });

            return questions;
        }

        public string Question { get; set; }

        public List<AnswerModel> Answers { get; set; }

        public override string ToString()
        {
            var message = Question;

            foreach (var Answer in Answers)
            {
                message += Answer.Code + ") " + Answer.Value;
            }

            return message;
        }
    }
}
