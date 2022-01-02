namespace TriviaApp.UI.Service.Utility
{
    public static class NumberToLetterUtility
    {
        private static readonly Dictionary<int, string> NumberToLetter = new Dictionary<int, string>
        {
            { 1, "a" },
            { 2, "b" },
            { 3, "c" },
            { 4, "d" },
            { 5, "e" },
            { 6, "f" },
            { 7, "g" },
        };

        public static string ConvertToLetter(int number)
        {
            if (number > 7)
            {
                throw new ArgumentException($"Only max number of {NumberToLetter.Count} is allowed.");
            }

            if (number < 0)
            {
                throw new ArgumentException("A number less than 1 is not allowed.");
            }

            return NumberToLetter[number];
        }
    }
}
