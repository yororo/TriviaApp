using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriviaApp.Domain.Model
{
    public class TriviaTrueFalseQuestion : TriviaQuestionBase
    {
        public bool Answer { get; set; }
    }
}
