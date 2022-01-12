using TriviaApp.Domain.Enum;
using TriviaApp.Domain.Model;

namespace TriviaApp.Domain.Interface
{
    public interface IQuestionTriviaService
    {
        public List<TriviaQuestionBase> GetQuestions(QuestionType type, QuestionDifficulty difficulty, QuestionCategory genre, int number);
    }
}
