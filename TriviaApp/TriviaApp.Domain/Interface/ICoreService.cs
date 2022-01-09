using TriviaApp.Domain.Enum;
using TriviaApp.Domain.Model;

namespace TriviaApp.Domain.Interface
{
    public interface ICoreService
    {
        public List<TriviaQuestionBase> GetQuestions(QuestionType type, QuestionDifficulty difficulty, QuestionCategory genre, int number);
        public List<TriviaBasicQuestion> GetAllQuestions();
    }
}
