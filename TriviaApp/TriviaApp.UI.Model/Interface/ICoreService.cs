using TriviaApp.UI.Model.TriviaQuestion.Question;

namespace TriviaApp.UI.Model.Interface
{
    public interface ICoreService
    {
        public Task<List<Question>> GetQuestionsAsync(int number, string type, string difficulty, string genre);
    }
}
