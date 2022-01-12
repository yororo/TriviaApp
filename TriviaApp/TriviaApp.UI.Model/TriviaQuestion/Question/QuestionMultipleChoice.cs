namespace TriviaApp.UI.Model.TriviaQuestion.Question
{
    public class QuestionMultipleChoice : Question
    {
        public string? Answer { get; set; }
        public List<string>? Choices { get; set; }
    }
}
