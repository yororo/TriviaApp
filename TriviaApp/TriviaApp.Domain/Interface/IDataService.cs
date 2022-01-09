using TriviaApp.Domain.Enum;
using TriviaApp.Domain.Model;

namespace TriviaApp.Domain.Interface
{
    public interface IDataService
    {
        public Task<List<TriviaQuestionBase>> GetQuestionsAsync(int number, QuestionType type, QuestionDifficulty difficulty, QuestionCategory genre);
    }
}
