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
        public EventCallback<bool?> IsAnswerCorrectChanged { get; set; }

        private string SelectedAnswer { get; set; } = string.Empty;

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
