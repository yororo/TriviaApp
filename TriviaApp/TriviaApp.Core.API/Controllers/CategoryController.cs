using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TriviaApp.Domain.Interface;

namespace TriviaApp.Core.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private ILogger<QuestionTriviaController> Logger { get; }
        private IQuestionDataService DataService { get; }

        public CategoryController(ILogger<QuestionTriviaController> logger, IQuestionDataService dataService)
        {
            Logger = logger;
            DataService = dataService;
        }

        [HttpGet("getcategories")]
        // GET: CategoryController/GetCategories
        public ActionResult GetCategories()
        {
            try
            {
                Logger.LogInformation($"[Start] {nameof(CategoryController)}.{nameof(this.GetCategories)}()");

                var result = DataService.GetCategories();
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
