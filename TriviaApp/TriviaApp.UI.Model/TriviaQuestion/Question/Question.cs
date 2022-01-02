namespace TriviaApp.UI.Model.TriviaQuestion.Question
{
    public abstract class Question
    {
        public string Text { get; set; } = string.Empty;
        public int Number { get; set; }
    }
}
