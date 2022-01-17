using Microsoft.Extensions.Logging;
using TriviaApp.Data.Model.Interface;
using TriviaApp.Data.Source.API.OpenTriviaAPI;
using TriviaApp.Domain.Enum;
using TriviaApp.Domain.Interface;
using TriviaApp.Domain.Model;

namespace TriviaApp.Data.Service
{
    public class QuestionDataService : IQuestionDataService
    {
        public ILogger<QuestionDataService> Logger { get; }
        public IDataServiceApi DataServiceApi { get; }

        public QuestionDataService(ILogger<QuestionDataService> logger, IDataServiceApi dataServiceApi)
        {
            Logger = logger;
            DataServiceApi = dataServiceApi;
        }

        public async Task<List<TriviaQuestionBase>> GetQuestionsAsync(int number, QuestionType type, QuestionDifficulty difficulty, QuestionCategory genre)
        {
            Logger.LogInformation($"[Start] {nameof(QuestionDataService)}.{nameof(GetQuestionsAsync)}()");

            var result = new List<TriviaQuestionBase>();

            try
            {
                var apiResult = await DataServiceApi.GetQuestionsAsync(number, type, difficulty, genre);

                if (apiResult != null)
                {
                    result.AddRange(apiResult);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);
            }

            return result;
        }

        public List<string> GetCategories()
        {
            var result = new List<string>();

            foreach (var category in Enum.GetNames(typeof(QuestionCategory)))
            {
                //var categoryName = category switch
                //{
                //    typeof(QuestionCategory).GetProperty(nameof(QuestionCategory.Animals)).Name => "Animals"
                //};
                result.Add(category);
            }

            return result;

        }
    }
}