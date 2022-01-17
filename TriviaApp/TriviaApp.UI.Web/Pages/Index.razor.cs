using Microsoft.AspNetCore.Components;
using TriviaApp.Domain.Enum;
using TriviaApp.UI.Model.Interface;
using TriviaApp.UI.Model.TriviaQuestion;

namespace TriviaApp.UI.Web.Pages
{
    public partial class Index
    {
        [Inject]
        public ICoreService CoreService { get; set; }

        [Inject]
        public ILogger<Index> Logger { get; set; }

        public List<Model.TriviaQuestion.Question.QuestionViewModel> Questions { get; set; } = new();
        public QuestionSetupViewModel QuestionSetup { get; set; } = new();
        public List<string> Categories { get; set; } = new();
        public bool ShowQuestions { get; set; }
        public bool ShowSpinner { get; set; }
        private int StartNumber { get; set; }
        public bool Finished { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Logger.LogInformation($"[Start] {nameof(Index)}.{nameof(this.OnInitializedAsync)}()");
            Categories = await CoreService.GetCategories();
            QuestionSetupSetDefaults();
        }

        private async Task GameOnClick()
        {
            StartNumber = 1;
            await LoadQuestions();
        }

        private void BackOnClick()
        {
            QuestionSetupSetDefaults();
            ShowQuestions = false;
            StartNumber = 1;
            Finished = false;
            Questions.Clear();
        }

        private async Task ResetOnClick()
        {
            Questions.Clear();
            await LoadQuestions();
            StartNumber = 1;
            Finished = false;
        }

        private async Task LoadQuestions()
        {
            try
            {
                ShowQuestions = true;
                ShowSpinner = true;

                var triviaQuestions = await CoreService.GetQuestionsAsync(QuestionSetup.NumberOfQuestions, Enum.GetName(QuestionType.MultipleChoice) ?? string.Empty, QuestionSetup.Difficulty, QuestionSetup.Category);

                ShowSpinner = false;

                if (triviaQuestions != null)
                {
                    Questions.AddRange(triviaQuestions);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);

                ShowQuestions = false;
            }
        }

        private void QuestionSetupSetDefaults()
        {
            QuestionSetup.Difficulty = Enum.GetName(QuestionDifficulty.Any)?.ToLower() ?? string.Empty;
            QuestionSetup.Category = Categories.FirstOrDefault()?.ToLower() ?? string.Empty;
            QuestionSetup.NumberOfQuestions = 10;
        }

        private void TestData()
        {
            //if (Questions.Count == 0)
            //{
            //    Questions.Add(
            //        new QuestionMultipleChoice
            //        {
            //            Number = 1,
            //            Text = "What is the largest animal?",
            //            Answer = "Blue whale",
            //            Choices = new List<string> { "Lion", "Giraffe", "Blue whale", "Rhino" }
            //        });

            //    Questions.Add(
            //        new QuestionMultipleChoice
            //        {
            //            Number = 2,
            //            Text = "Which mammal is known to have the most powerful bite in the world? ",
            //            Answer = "Hippopotamus",
            //            Choices = new List<string> { "Tiger", "Hippopotamus", "Phiranna", "Ant" }
            //        });

            //    Questions.Add(
            //        new QuestionMultipleChoice
            //        {
            //            Number = 3,
            //            Text = "What is the collective noun for rats?",
            //            Answer = "Mischief",
            //            Choices = new List<string> { "Pack", "Mischief", "Race", "Drift" }
            //        });
            //}
        }
    }
}
