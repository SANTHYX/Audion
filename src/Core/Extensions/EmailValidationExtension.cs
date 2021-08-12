namespace Core.Extensions
{
    public static class EmailValidationExtension
    {
        public static bool IsValidEmail(this string value)
            => value.Contains('@');
    }
}
