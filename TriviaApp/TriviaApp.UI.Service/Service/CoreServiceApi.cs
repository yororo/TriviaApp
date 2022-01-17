using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System.Web;
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

        public async Task<List<QuestionViewModel>> GetQuestionsAsync(int number, string type, string difficulty, string category)
        {
            Logger.LogInformation($"[Start] {nameof(CoreServiceApi)}.{nameof(GetQuestionsAsync)}()");

            var apiResult = new List<TriviaQuestionBase>();
            
            var result = new List<QuestionViewModel>();
            
            var typeParameter = 
                type.ToLower() switch
                {
                    "multiplechoice" => QuestionType.MultipleChoice,
                    _ => QuestionType.MultipleChoice,
                };

            var difficultyParameter =
                difficulty.ToLower() switch
                {
                    "easy" => QuestionDifficulty.Easy,
                    "medium" => QuestionDifficulty.Medium,
                    "hard" => QuestionDifficulty.Hard,
                    _ => QuestionDifficulty.Any
                };

            // TODO: make this dynamic
            var categoryParameter =
                category switch
                {
                    "animals" => QuestionCategory.Animals,
                    "movies" => QuestionCategory.Movie,
                    "music" => QuestionCategory.Music,
                    _ => QuestionCategory.Any
                };

            var requestUri = $"api/questiontrivia/getquestions?number={number}&type={typeParameter}&difficulty={difficultyParameter}&category={categoryParameter}";

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
                        var questionViewModel = new QuestionMultipleChoiceViewModel();
                        questionViewModel.Number = questionNnumber;
                        questionViewModel.Answer = HttpUtility.HtmlDecode(multipleChoiceQuestion.CorrectAnswer);
                        questionViewModel.Text = HttpUtility.HtmlDecode(multipleChoiceQuestion.Question);

                        var choices = multipleChoiceQuestion.IncorrectAnswers?.ToList();

                        if (multipleChoiceQuestion.CorrectAnswer != null)
                        {
                            choices?.Add(multipleChoiceQuestion.CorrectAnswer);
                        }                        

                        questionViewModel.Choices = choices?.Select(x => HttpUtility.HtmlDecode(x)).OrderBy(x => rng.Next()).ToList();

                        result.Add(questionViewModel);

                        questionNnumber++;
                    }
                }
            }

            return result;
        }

        public async Task<List<string>> GetCategories()
        {
            Logger.LogInformation($"[Start] {nameof(CoreServiceApi)}.{nameof(GetCategories)}()");

            var result = new List<string>();

            var requestUri = $"api/Category/getcategories";

            var httpRequest = new HttpRequestMessage(HttpMethod.Get, requestUri);

            try
            {
                var response = await HttpClient.SendAsync(httpRequest);

                if (response != null && response.Content != null && response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    // TODO: make this dynamic to accomodate other question types or revisit the model design
                    var categories = JsonConvert.DeserializeObject<List<string>>(content);

                    if (categories != null)
                    {
                        result.AddRange(categories);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }

            return result;
        }
    }
}
