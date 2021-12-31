namespace TriviaApp.Web.ViewModels
{
    public class TriviaQuestionViewModel
    {
        public string Number { get; set; }
        public string Question { get; set; }
        public int Points { get; set; }
        public List<string> Choices { get; set; }
        public List<string> Answers { get; set; }
    }
}
