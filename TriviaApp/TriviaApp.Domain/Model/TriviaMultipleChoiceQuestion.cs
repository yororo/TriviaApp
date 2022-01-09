namespace TriviaApp.Domain.Model
{
    public class TriviaMultipleChoiceQuestion : TriviaQuestionBase
    {
        public List<string>? IncorrectAnswers { get; set; }
        public string? CorrectAnswer { get; set; }
    }
}
