using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TriviaApp.Domain.Enum;
using TriviaApp.Domain.Interface;
using TriviaApp.Domain.Model;

namespace TriviaApp.Core.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionTriviaController : Controller
    {
        private ILogger<QuestionTriviaController> Logger { get; }
        private IQuestionDataService DataService { get; }

        public QuestionTriviaController(ILogger<QuestionTriviaController> logger, IQuestionDataService dataService)
        {
            Logger = logger;
            DataService = dataService;
        }

        [HttpGet("getquestions")]
        // GET: QuestionTriviaController/GetQuestions
        public async Task<ActionResult> GetQuestions(int number, QuestionType type, QuestionDifficulty difficulty, QuestionCategory category)
        {
            try
            {
                Logger.LogInformation($"[Start] {nameof(QuestionTriviaController)}.{nameof(this.GetQuestions)}()");

                var result = await DataService.GetQuestionsAsync(number, type, difficulty, category);
                var serializedResult = JsonConvert.SerializeObject(result);
                return Ok(serializedResult);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);

                return Problem($"Error: {ex.Message}");
            }
        }
    }
}
