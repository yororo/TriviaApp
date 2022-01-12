using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using TriviaApp.Data.Model.Interface;
using TriviaApp.Data.Source.API.OpenTriviaAPI.Model;
using TriviaApp.Data.Source.API.OpenTriviaAPI.Translator;
using TriviaApp.Domain.Enum;
using TriviaApp.Domain.Model;

namespace TriviaApp.Data.Source.API.OpenTriviaAPI
{
    public class DataServiceOpenTriviaApi : IDataServiceApi
    {
        private const string BASE_URL = "https://opentdb.com/api.php?";

        public ILogger<DataServiceOpenTriviaApi> Logger { get; }

        public DataServiceOpenTriviaApi(ILogger<DataServiceOpenTriviaApi> logger)
        {
            Logger = logger;
        }

        public async Task<List<TriviaQuestionBase>> GetQuestionsAsync(int number, QuestionType type, QuestionDifficulty difficulty, QuestionCategory category)
        {
            Logger.LogInformation($"[Start] {nameof(DataServiceOpenTriviaApi)}.{nameof(GetQuestionsAsync)}()");

            var result = new List<TriviaQuestionBase>();
            var client = new RestClient(BASE_URL);
            var request = new RestRequest();

            request.AddQueryParameter("amount", number);

            if (type != QuestionType.Any)
            {
                request.AddQueryParameter("type", TypeTranslator.TranslateToOpenTrivia(type));
            }

            if (difficulty != QuestionDifficulty.Any)
            {
                request.AddQueryParameter("difficulty", DifficultyTranslator.TranslateToOpenTrivia(difficulty));
            }

            if (category != QuestionCategory.Any)
            {
                request.AddQueryParameter("category", CategoryTranslator.TranslateToOpenTrivia(category));
            }

            try
            {
                var response = await client.ExecuteAsync(request);

                if (response != null && response.Content != null && response.IsSuccessful)
                {
                    var openTriviaResponse = JsonConvert.DeserializeObject<OpenTriviaResponse>(response.Content);

                    //Response Codes
                    //The API appends a "Response Code" to each API Call to help tell developers what the API is doing.
                    //Code 0: Success Returned results successfully.
                    //Code 1: No Results Could not return results.The API doesn't have enough questions for your query. (Ex. Asking for 50 Questions in a Category that only has 20.)
                    //Code 2: Invalid Parameter Contains an invalid parameter. Arguements passed in aren't valid. (Ex. Amount = Five)
                    //Code 3: Token Not Found Session Token does not exist.
                    //Code 4: Token Empty Session Token has returned all possible questions for the specified query.Resetting the Token is necessary.
                    if (openTriviaResponse != null && openTriviaResponse.Results != null)
                    {
                        foreach (var openTriviaResult in openTriviaResponse.Results)
                        {
                            if (openTriviaResult.Type == "multiple")
                            {
                                result.Add(new TriviaMultipleChoiceQuestion
                                {
                                    Question = openTriviaResult.Question,
                                    CorrectAnswer = openTriviaResult.Correct_Answer,
                                    IncorrectAnswers = openTriviaResult.Incorrect_Answers
                                });
                            }
                        }
                    }
                }
                else
                {
                    Logger.LogError("Call to API failed.");
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
