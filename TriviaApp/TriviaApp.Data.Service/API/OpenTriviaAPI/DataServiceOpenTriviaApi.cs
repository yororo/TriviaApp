using Newtonsoft.Json;
using RestSharp;
using TriviaApp.Data.Service.API.OpenTriviaAPI.Model;
using TriviaApp.Data.Service.API.OpenTriviaAPI.Translator;
using TriviaApp.Domain.Enum;
using TriviaApp.Domain.Interface;
using TriviaApp.Domain.Model;

namespace TriviaApp.Data.Service.API.OpenTriviaAPI
{
    public class DataServiceOpenTriviaApi : IDataService
    {
        private const string BASE_URL = "https://opentdb.com/api.php";

        public async Task<List<TriviaQuestionBase>> GetQuestionsAsync(int number, QuestionType type, QuestionDifficulty difficulty, QuestionCategory category)
        {
            var result = new List<TriviaQuestionBase>();
            var client = new RestClient(BASE_URL);
            var request = new RestRequest();

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

                    if (openTriviaResponse != null && openTriviaResponse.ResponseCode == "0" && openTriviaResponse.Results != null)
                    {
                        foreach (var openTriviaResult in openTriviaResponse.Results)
                        {
                            if (openTriviaResult.Type == "multiple")
                            {
                                result.Add(new TriviaMultipleChoiceQuestion
                                {
                                    Question = openTriviaResult.Question,
                                    CorrectAnswer = openTriviaResult.CorrectAnswer,
                                    IncorrectAnswers = openTriviaResult.IncorrectAnswers
                                });
                            }
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                // TODO
            }

            return result;
        }
    }
}
