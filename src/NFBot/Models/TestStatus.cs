using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NFBot.Models
{
    public enum TestStatus
    {
        Finished,
        Continue,
        IncorrectAnswer
    }

    public enum AnswerStatus
    {
        Incorrect, Correct
    }
}
