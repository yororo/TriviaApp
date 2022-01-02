namespace TriviaApp.UI.Model.TriviaQuestion.Question
{
    public class QuestionMultipleChoice : Question
    {
        public string Answer { get; set; } = string.Empty;
        public List<string> Choices { get; set; } = new();
    }
}
