﻿using System;
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

            result.Add( new TestDescriptionResults() { Code = "А", Description = "АГРЕССОР \n\n Вы - агрессор(преимущественно мужской тип).Сила, власть и напор, граничащие с грубостью, -вот ваш стиль в любви.Вы не признаете недомолвок, намеков, предпочитая действовать открыто и прямолинейно.Ваше сексуальное начало похоже на вулкан - завораживает, как любое проявление дикой природы, но может испепелить огнедышащей лавой." });

            result.Add(new TestDescriptionResults() { Code = "Б", Description = "ИНТЕЛЛЕКТУАЛ \n\n Вы - интеллектуал (в равной степени мужской и женский тип) и склонны все оценивать с точки зрения здравого смысла. Используете и анализируете свои чувства, пытаетесь классифицировать объект своей привязанности. Вы мудры, проницательны и никогда не теряете головы, даже если любовь возносит вас к вершинам блаженства." });

            result.Add(new TestDescriptionResults() { Code = "В", Description = "АЖЕРТВА \n\n Вы - жертва. 'Настоящая любовь всегда сопряжена с болью!' - так думаете вы, обрекая себя на страдания. Вы готовы на все во имя спасения любви. А если она не нуждается в спасении, придумываете себе препятствия, преодоление которых потребует от вас максимум самоотречения" });

            result.Add(new TestDescriptionResults() { Code = "Г", Description = "РОМАНТИК \n\n Значит, вы - романтик. Самый важный вопрос человечества 'Быть или не быть ? ' у вас трансформируется в 'Любить или не любить ? '. Если вас настигает любовь, то с большой буквы и навсегда. Вы постоянно хотите быть в поле зрения любимого человека, слышать его, прикасаться к нему... По вашему, вообще лучше обходиться без секса, чем позволить себе связь, не освященную любовью." });

            result.Add(new TestDescriptionResults() { Code = "Д", Description = "ЦИНИК \n\n Вы - циник (преимущественно мужской тип). Не верите в любовь ни с первого, ни со второго взгляда. Любое проявление нежных чувств вызывает в вас желание поиронизировать. Ничто не может затронуть ваше сердце, надежно скрытое под броней скептицизма. А если иногда и краснеете, то только от удовольствия." });

            result.Add(new TestDescriptionResults() { Code = "", Description =@"ЭГОИСТ \n\n Значит, вы - эгоист (в равной степени мужской и женский тип). Искренне верите в свою исключительность и любите не партнера, а себя в партнере. Любимый человек для вас - лишь приложение, на которое падает отблеск вашего сияния. Если вам покажется, что он перестал справляться с ролью восторженной толпы, вы испытываете дискомфорт и начнете искать дополнительные источники вдохновения." });

            return result;
        }
        
        public string Code { get; set; }

        public string Description { get; set; }
    }
}
