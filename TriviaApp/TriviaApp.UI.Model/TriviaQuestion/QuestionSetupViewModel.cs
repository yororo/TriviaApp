namespace TriviaApp.UI.Model.TriviaQuestion
{
    public class QuestionSetupViewModel
    {
        public string Difficulty { get; set; } = string.Empty;
        public int NumberOfQuestions { get; set; }
        public string Category { get; set; } = string.Empty;
    }
}
