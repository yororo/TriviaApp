using Microsoft.AspNetCore.Components;
using TriviaApp.UI.Service.Helper;

namespace TriviaApp.UI.Web.Pages.Question
{
    public partial class QuestionComponent
    {
        [Parameter]
        public Model.TriviaQuestion.Question.Question? Question { get; set; }
        
        [Parameter]
        public bool Hide { get; set; }

        [Parameter]
        public int TotalQuestions { get; set; }

        [Parameter]
        public EventCallback<bool?> IsAnswerCorrectChanged { get; set; }

        [Parameter]
        public EventCallback<bool?> IsNextClickedChanged { get; set; }

        private string SelectedAnswer { get; set; } = string.Empty;
        private bool ShowNextButton { get; set; } = false;

        protected override void OnInitialized()
        {
            SelectedAnswer = string.Empty;
            ShowNextButton = false;
        }

        private async Task OnSubmitClick()
        {
            if (Question != null)
            {
                if (!string.IsNullOrEmpty(SelectedAnswer))
                {
                    await IsAnswerCorrectChanged.InvokeAsync(Question.CheckAnswer(SelectedAnswer));
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
