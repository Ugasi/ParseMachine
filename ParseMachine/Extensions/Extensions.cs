namespace ParseMachine.Extensions
{
    internal static class Extensions
    {
        public static string RemoveWhiteSpace(this string value)
        {
            return value.Replace("\n", "").Trim();
        }
    }
}