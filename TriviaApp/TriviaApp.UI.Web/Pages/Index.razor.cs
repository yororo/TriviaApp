using TriviaApp.UI.Model.TriviaQuestion;
using TriviaApp.UI.Model.TriviaQuestion.Question;

namespace TriviaApp.UI.Web.Pages
{
    public partial class Index
    {
        public QuestionSetupViewModel QuestionSetup { get; set; } = new();
        public List<Model.TriviaQuestion.Question.Question> Questions { get; set; } = new();
        public bool ShowQuestions { get; set; }

        protected override void OnInitialized()
        {
            Questions.Add(
                new QuestionMultipleChoice
                {
                    Number = 1,
                    Text = "What is the largest animal?",
                    Answer = "Blue whale",
                    Choices = new List<string> { "Lion", "Giraffe", "Blue whale", "Rhino" }
                });

            Questions.Add(
                new QuestionMultipleChoice
                {
                    Number = 2,
                    Text = "Which mammal is known to have the most powerful bite in the world? ",
                    Answer = "Hippopotamus",
                    Choices = new List<string> { "Tiger", "Hippopotamus", "Phiranna", "Ant" }
                });

            Questions.Add(
                new QuestionMultipleChoice
                {
                    Number = 3,
                    Text = "What is the collective noun for rats?",
                    Answer = "Mischief",
                    Choices = new List<string> { "Pack", "Mischief", "Race", "Drift" }
                });
        }

        private void GameOnClick()
        {
            ShowQuestions = true;
        }
    }
}
