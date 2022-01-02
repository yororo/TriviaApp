using TriviaApp.UI.Model.TriviaQuestion.Question;

namespace TriviaApp.UI.Service.Helper
{
    public static class QuestionHelper
    {
        public static bool CheckAnswer(this Question question, string answer)
        {
            if (question != null)
            {
                var questionMultipleChoice = question as QuestionMultipleChoice;

                if (questionMultipleChoice != null)
                {
                    return questionMultipleChoice.Answer.Trim().ToLower() == answer.Trim().ToLower();
                }
            }

            return false;
        }
    }
}
