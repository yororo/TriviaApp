using TriviaApp.Domain.Enum;

namespace TriviaApp.Data.Source.API.OpenTriviaAPI.Translator
{
    internal static class CategoryTranslator
    {
        public static string TranslateToOpenTrivia(QuestionCategory questionType)
        {
            return questionType switch
            {
                QuestionCategory.Animals => "27",
                QuestionCategory.Books => "10",
                QuestionCategory.Celebrities => "26",
                QuestionCategory.Comics => "29",
                QuestionCategory.Computers => "18",
                QuestionCategory.General => "9",
                QuestionCategory.Geography => "22",
                QuestionCategory.History => "23",
                QuestionCategory.Movie => "11",
                QuestionCategory.Music => "12",
                QuestionCategory.MusicalAndTheatre => "13",
                QuestionCategory.Mythology => "20",
                QuestionCategory.ScienceAndNature => "17",
                QuestionCategory.Sports => "21",
                QuestionCategory.Television => "14",
                QuestionCategory.Vehicles => "28",
                _ => string.Empty,
            };
        }
    }
}
