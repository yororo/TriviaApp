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

        protected override void OnInitialized()
        {
            SelectedAnswer = string.Empty;
            ShowNextButton = false;
            IsCorrect = null;
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
                }
            }

            await IsAnswerCorrectChanged.InvokeAsync(false);
            ShowNextButton = true;
        }

        private async Task OnNextClick()
        {
            await IsNextClickedChanged.InvokeAsync(true);

            SelectedAnswer = string.Empty;
            ShowNextButton = false;
            IsCorrect = null;

            StateHasChanged();
        }

        private void OnSelectionChange(ChangeEventArgs e)
        {
            var selectedAnswer = e.Value?.ToString();

            if (selectedAnswer != null)
            {
                SelectedAnswer = selectedAnswer;
            }
        }
    }
}
