namespace TriviaApp.Data.Service.API.OpenTriviaAPI.Model
{
    internal record OpenTriviaResponse
    {
        public string? ResponseCode { get; set; }
        public List<OpenTriviaResponseResult>? Results { get; set; }

    }
}
