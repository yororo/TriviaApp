using TriviaApp.UI.Model.TriviaQuestion.Enums;

namespace TriviaApp.UI.Model.TriviaQuestion
{
    public class Question
    {
        public string Text { get; set; } = string.Empty;
        public int Number { get; set; }
        public List<string> Answers { get; set; } = new();
        public List<string> Choices { get; set; } = new();
        public QuestionType Type { get; set; }
    }
}
