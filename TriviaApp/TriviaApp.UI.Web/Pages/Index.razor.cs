using Microsoft.AspNetCore.Components;
using TriviaApp.Domain.Enum;
using TriviaApp.Domain.Interface;
using TriviaApp.Domain.Model;
using TriviaApp.UI.Model.Interface;
using TriviaApp.UI.Model.TriviaQuestion;
using TriviaApp.UI.Model.TriviaQuestion.Question;

namespace TriviaApp.UI.Web.Pages
{
    public partial class Index
    {
        [Inject]
        public ICoreService CoreService { get; set; }

        [Inject]
        public ILogger<Index> Logger { get; set; }

        public List<Model.TriviaQuestion.Question.Question> Questions { get; set; } = new();
        public QuestionSetupViewModel QuestionSetup { get; set; } = new();
        public bool ShowQuestions { get; set; }
        
        protected override void OnInitialized()
        {
            Logger.LogInformation($"[Start] {nameof(Index)}.{nameof(OnInitialized)}()");

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

        private async Task GameOnClick()
        {
            try
            {
                var triviaQuestions = await CoreService.GetQuestionsAsync(10, Enum.GetName(QuestionType.MultipleChoice), QuestionSetup.Difficulty, QuestionSetup.Category);

                if (triviaQuestions != null)
                {
                    Questions.AddRange(triviaQuestions);
                }

                ShowQuestions = true;
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, ex.Message);

                ShowQuestions = false;
            }
        }
    }
}
