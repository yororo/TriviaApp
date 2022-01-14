namespace TriviaApp.UI.Model.TriviaQuestion.Question
{
    public class QuestionMultipleChoiceViewModel : QuestionViewModel
    {
        public string? Answer { get; set; }
        public List<string>? Choices { get; set; }
    }
}
