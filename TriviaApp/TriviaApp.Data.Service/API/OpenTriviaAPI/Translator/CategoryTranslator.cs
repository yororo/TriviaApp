using TriviaApp.Domain.Enum;

namespace TriviaApp.Data.Service.API.OpenTriviaAPI.Translator
{
    internal static class CategoryTranslator
    {
        public static string TranslateToOpenTrivia(QuestionCategory questionType)
        {
            return questionType switch
            {
                QuestionCategory.General => "9",
                QuestionCategory.Movie => "11",
                QuestionCategory.Animals => "7",
                QuestionCategory.Music => "12",
                _ => string.Empty,
            };
        }
    }
}
