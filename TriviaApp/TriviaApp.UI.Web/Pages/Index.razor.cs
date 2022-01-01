using TriviaApp.UI.Model.TriviaQuestion;

namespace TriviaApp.UI.Web.Pages
{
    public partial class Index
    {
        public QuestionSetup QuestionSetup { get; set; }
        public List<Question> Questions { get; set; }

        protected override void OnInitialized()
        {
            QuestionSetup = new QuestionSetup();
            Questions = new List<Question>();
        }
    }
}
