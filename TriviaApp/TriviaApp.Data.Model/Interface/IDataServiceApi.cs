using TriviaApp.Domain.Enum;
using TriviaApp.Domain.Model;

namespace TriviaApp.Data.Model.Interface
{
    public interface IDataServiceApi
    {
        public Task<List<TriviaQuestionBase>> GetQuestionsAsync(int number, QuestionType type, QuestionDifficulty difficulty, QuestionCategory genre);
    }
}
