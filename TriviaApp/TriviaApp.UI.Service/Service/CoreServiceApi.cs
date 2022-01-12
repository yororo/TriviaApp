using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using TriviaApp.Domain.Enum;
using TriviaApp.Domain.Model;
using TriviaApp.UI.Model.Interface;
using TriviaApp.UI.Model.TriviaQuestion.Question;

namespace TriviaApp.UI.Service.Service
{
    public class CoreServiceApi : ICoreService
    {
        public ILogger<CoreServiceApi> Logger { get; }
        public HttpClient HttpClient { get; }

        private static Random rng = new Random();

        public CoreServiceApi(ILogger<CoreServiceApi> logger, HttpClient httpClient)
        {
            Logger = logger;
            HttpClient = httpClient;
        }

        // TODO: this should return viewmodel
        public async Task<List<Question>> GetQuestionsAsync(int number, string type, string difficulty, string genre)
        {
            Logger.LogInformation($"[Start] {nameof(CoreServiceApi)}.{nameof(GetQuestionsAsync)}()");

            var apiResult = new List<TriviaQuestionBase>();
            
            var result = new List<Question>();
            
            var typeParameter = 
                type.ToLower() switch
                {
                    "multiplechoice" => QuestionType.MultipleChoice,
                    _ => QuestionType.MultipleChoice,
                };

            var difficultyParameter =
                difficulty.ToLower() switch
                {
                    "medium" => "medium",
                    "hard" => "hard",
                    _ => "easy"
                };

            var genreParameter =
                genre switch
                {
                    "animals" => 27,
                    "movies" => 3,
                    "books" => 10,
                    _ => 9 // general knowledge
                };

            var requestUri = $"questiontrivia?number={number}&type={typeParameter}&difficulty={difficultyParameter}&genre={genreParameter}";

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, requestUri);

            try
            {
                var response = await HttpClient.SendAsync(httpRequest);

                if (response != null && response.Content != null && response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // TODO: make this dynamic to accomodate other question types or revisit the model design
                    var triviaQuestions = JsonConvert.DeserializeObject<List<TriviaMultipleChoiceQuestion>>(content);

                    if (triviaQuestions != null)
                    {
                        apiResult.AddRange(triviaQuestions);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }

            int questionNnumber = 1;
            foreach (var question in apiResult)
            {
                if (question is TriviaMultipleChoiceQuestion)
                {
                    var multipleChoiceQuestion = question as TriviaMultipleChoiceQuestion;

                    if (multipleChoiceQuestion != null)
                    {
                        var questionViewModel = new QuestionMultipleChoice();
                        questionViewModel.Number = questionNnumber;
                        questionViewModel.Answer = multipleChoiceQuestion.CorrectAnswer;
                        questionViewModel.Text = multipleChoiceQuestion.Question;

                        var choices = multipleChoiceQuestion.IncorrectAnswers?.ToList();

                        if (multipleChoiceQuestion.CorrectAnswer != null)
                        {
                            choices?.Add(multipleChoiceQuestion.CorrectAnswer);
                        }                        

                        questionViewModel.Choices = choices?.OrderBy(x => rng.Next()).ToList();

                        result.Add(questionViewModel);

                        questionNnumber++;
                    }
                }
            }

            return result;
        }
    }
}
