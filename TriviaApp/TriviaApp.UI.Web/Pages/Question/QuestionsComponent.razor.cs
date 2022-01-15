using Microsoft.AspNetCore.Components;
using TriviaApp.UI.Model.TriviaQuestion.Question;

namespace TriviaApp.UI.Web.Pages.Question
{
    public partial class QuestionsComponent
    {
        [Parameter]
        public List<QuestionViewModel>? Questions { get; set; }

        [Parameter]
        public int CurrentNumber { get; set; }

        public QuestionViewModel? CurrentQuestion { get; set; }

        public bool Finished { get; set; }

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

        protected void IsNextClicked(bool? isCorrect)
        {
            if (Questions != null && CurrentQuestion != null)
            {
                if (CurrentNumber < Questions.Count)
                {
                    CurrentNumber += 1;
                }
                else
                {
                    Finished = true;
                }
            }

            StateHasChanged();
        }
    }
}
