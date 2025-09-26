namespace Extensions
{
    public static class WordFormExtensions
    {
        public static string GetWordForm(this int num, 
            string singular, string plural, string genitive)
        {
            if (num > 4) return plural;

            switch (num)
            {
                case 1:
                    return singular;
                case 2:
                case 3:
                case 4:
                    return genitive;
                default:
                    return string.Empty;
            }
        }
    }
}
