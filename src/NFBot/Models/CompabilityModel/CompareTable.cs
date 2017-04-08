using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models.CompabilityModel
{
    public class CompareTable
    {
        public static List<CompareTable> Init()
        {
            List<CompareTable> result = new List<CompareTable>();

            result.Add(new CompareTable() { Code = "АA",
                Description = "Агрессор + Агрессор \n Продлится до тех пор, пока один из вас не потеряет интерес." });

            result.Add(new CompareTable() { Code = "АБ",
                Description = "Агрессор + Интеллектуал \n Интеллектуал Может не понимать агрессии и избыточной страсти, и в конечном итоге расстаться с агрессором." });

            result.Add(new CompareTable() { Code = "АВ",
                Description = "Агрессор + Жертва \n Идеальные типы людей." });

            result.Add(new CompareTable() { Code = "АГ",
                Description = "Агрессор + Романтик \n Отличный союз, но агрессору не стоит перигибать палку" });

            result.Add(new CompareTable() { Code = "АД",
                Description = "Агрессор + Циник \n Отношения могут не закончится хорошо." });

            result.Add(new CompareTable() { Code = "АЕ",
                Description = "Агрессор + Эгоист \n Агрессор будет в недоумении от такого безразличия к себе. Стоит ли оно того?" });



            result.Add(new CompareTable() { Code = "ББ",
                Description = "Интеллектуал + Интеллектуал \n Отличная пара." });

            result.Add(new CompareTable() { Code = "БВ",
                Description = "Интеллектуал + Жертва \n Хорошая пара" });

            result.Add(new CompareTable() { Code = "БГ",
                Description = "Интеллектуал + Романтик \n Спокойные отношения." });

            result.Add(new CompareTable() { Code = "БД",
                Description = "Интеллектуал + Циник \n Жизнь будет наполнена конфронтацией" });

            result.Add(new CompareTable() { Code = "БЕ",
                Description = "Интеллектуал + Эгоист \n Будет всё хрошо, пока Эгоист сможет удивить интеллектуала" });



            result.Add(new CompareTable() { Code = "ВВ",
                Description = "Жертва + Жертва \n Безвкусные отношения. Но спокойные и стабильные." });

            result.Add(new CompareTable() { Code = "ВГ",
                Description = "Жертва + Романтик \n Ситуация, когда идея самопожертвования достигает своего апогея! " });

            result.Add(new CompareTable() { Code = "ВД",
                Description = "Жертва + Циник \n Один любит страдания, а другой - смеяться над ними. " });

            result.Add(new CompareTable() { Code = "ВЕ",
                Description = "Жертва + Эгоист \n Один делает все, чтобы доставить удовольствие другому, а другой с благосклонностью это принимает. Ваша совместная жизнь продлится долго." });


            result.Add(new CompareTable() { Code = "ГГ",
                Description = "Романтик + Романтик  \n Совершенное равновесие - взгляды на жизнь, любовь и секс совпадают с точностью до миллиметра." });

            result.Add(new CompareTable() { Code = "ГД",
                Description = "Романтик + Циник \n Один склонен идеализировать все и вся, а другого смешит любое проявление мечтательности и романтизма." });

            result.Add(new CompareTable() { Code = "ГЕ",
                Description = "Романтик + Эгоист \n Романтически-гуманистические устремления одного, причудливо переплетаясь с пестованием своего Я второго, образуют некое подобие гармонии." });


            result.Add(new CompareTable() { Code = "ДД",
                Description = "Циник + Циник \n Перспективы на любовные отношения равны нулю. Для временных увлечений подойдет." });

            result.Add(new CompareTable() { Code = "ДЕ",
                Description = "Жертва + Эгоист \n Один делает все, чтобы доставить удовольствие другому, а другой с благосклонностью это принимает." });


            result.Add(new CompareTable() { Code = "EЕ",
                Description = "Эгоист + Эгоист \n 'Любишь ли ты меня, как я люблю себя ? '. Можно построить отношения, но о самопожертвование забудете. " });


            return result;
        }

        public string Code { get; set; }

        public string Description { get; set; }
    }
}
