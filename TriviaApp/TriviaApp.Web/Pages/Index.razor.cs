using TriviaApp.Web.ViewModels;

namespace TriviaApp.Web.Pages
{
    public partial class Index
    {
        public TriviaQuestionSetupViewModel TriviaQuestionSetupViewModel { get; set; }
        public List<TriviaQuestionViewModel> Questions { get; set; }

        public string? Question1Answer { get; set; }

        public Index()
        {
            TriviaQuestionSetupViewModel = new TriviaQuestionSetupViewModel();
            Questions = new List<TriviaQuestionViewModel>();
        }
    }
}
