using TriviaApp.Domain.Enum;
using TriviaApp.Domain.Model;

namespace TriviaApp.Domain.Interface
{
    public interface IQuestionDataService
    {
        public Task<List<TriviaQuestionBase>> GetQuestionsAsync(int number, QuestionType type, QuestionDifficulty difficulty, QuestionCategory genre);
        public List<string> GetCategories();
    }
}
