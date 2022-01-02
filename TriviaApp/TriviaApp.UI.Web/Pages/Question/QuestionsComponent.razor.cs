using Microsoft.AspNetCore.Components;
using TriviaApp.UI.Model.TriviaQuestion.Question;

namespace TriviaApp.UI.Web.Pages.Question
{
    public partial class QuestionsComponent
    {
        [Parameter]
        public List<Model.TriviaQuestion.Question.Question>? Questions { get; set; }

        public Model.TriviaQuestion.Question.Question? CurrentQuestion { get; set; }

        private int CurrentNumber { get; set; }
        private int Score { get; set; }

        protected override void OnInitialized()
        {
            CurrentNumber = 1;
            Score = 0;
        }

        protected void IsAnswerCorrect(bool? isCorrect)
        {
            if (isCorrect.HasValue && isCorrect.Value)
            {
                Score += 1;
            }
        }
    }
}
