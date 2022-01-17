using Microsoft.AspNetCore.Components;
using TriviaApp.UI.Model.TriviaQuestion.Question;
using TriviaApp.UI.Service.Helper;

namespace TriviaApp.UI.Web.Pages.Question
{
    public partial class QuestionComponent
    {
        [Parameter]
        public QuestionViewModel? Question { get; set; }
        
        [Parameter]
        public bool Hide { get; set; }

        [Parameter]
        public int TotalQuestions { get; set; }

        [Parameter]
        public EventCallback<bool?> IsAnswerCorrectChanged { get; set; }

        [Parameter]
        public EventCallback<bool?> IsNextClickedChanged { get; set; }

        public bool? IsCorrect { get; set; }

        private string SelectedAnswer { get; set; } = string.Empty;
        private bool ShowNextButton { get; set; } = false;
        private string AnimationCss = string.Empty;
        private const string ANIMATION_CSS_CLASS = "animate__animated animate__rotateInDownRight";

        protected override void OnInitialized()
        {
            SelectedAnswer = string.Empty;
            ShowNextButton = false;
            IsCorrect = null;
            AnimationCss = ANIMATION_CSS_CLASS;
        }

        private async Task OnSubmitClick()
        {
            if (Question != null)
            {
                if (!string.IsNullOrEmpty(SelectedAnswer))
                {
                    var isCorrect = Question.CheckAnswer(SelectedAnswer);
                    await IsAnswerCorrectChanged.InvokeAsync(isCorrect);
                    IsCorrect = isCorrect;
                    AnimationCss = string.Empty;
                }
            }

            await IsAnswerCorrectChanged.InvokeAsync(false);
            ShowNextButton = true;
        }

        private async Task OnNextClick()
        {
            await IsNextClickedChanged.InvokeAsync(true);
            AnimationCss = ANIMATION_CSS_CLASS;
            SelectedAnswer = string.Empty;
            ShowNextButton = false;
            IsCorrect = null;

            StateHasChanged();
        }
    }
}
