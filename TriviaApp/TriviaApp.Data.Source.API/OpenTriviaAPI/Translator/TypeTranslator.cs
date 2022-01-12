using TriviaApp.Domain.Enum;

namespace TriviaApp.Data.Source.API.OpenTriviaAPI.Translator
{
    internal static class TypeTranslator
    {
        public static string TranslateToOpenTrivia(QuestionType questionType)
        {
            return questionType switch
            {
                QuestionType.MultipleChoice => "multiple",
                QuestionType.TrueFalse => "boolean",
                _ => string.Empty,
            };
        }
    }
}
