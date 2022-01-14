using TriviaApp.UI.Model.TriviaQuestion.Question;

namespace TriviaApp.UI.Service.Helper
{
    public static class QuestionHelper
    {
        public static bool CheckAnswer(this QuestionViewModel question, string answer)
        {
            if (question != null)
            {
                var questionMultipleChoice = question as QuestionMultipleChoiceViewModel;

                if (questionMultipleChoice != null)
                {
                    return questionMultipleChoice.Answer.Trim().ToLower() == answer.Trim().ToLower();
                }
            }

            return false;
        }
    }
}
