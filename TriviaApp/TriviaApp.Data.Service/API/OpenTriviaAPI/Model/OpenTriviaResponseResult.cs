namespace TriviaApp.Data.Service.API.OpenTriviaAPI.Model
{
    internal record OpenTriviaResponseResult
    {
        public string? Category { get; set; }
        public string? Type { get; set; }
        public string? Difficulty { get; set; }
        public string? Question { get; set; }
        public string? CorrectAnswer { get; set; }
        public List<string>? IncorrectAnswers { get; set; }
    }
}
