using TriviaApp.Domain.Enum;

namespace TriviaApp.Data.Service.API.OpenTriviaAPI.Translator
{
    internal static class DifficultyTranslator
    {
        public static string TranslateToOpenTrivia(QuestionDifficulty questionDifficulty)
        {
            return questionDifficulty switch
            {
                QuestionDifficulty.Easy => "easy",
                QuestionDifficulty.Medium => "medium",
                QuestionDifficulty.Hard => "hard",
                _ => string.Empty,
            };
        }
    }
}
