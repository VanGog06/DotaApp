namespace DotaApp.Common
{
    public static class Constants
    {
        public const string UsernameTaken = "Username is already taken";

        public const string IncorrectUsernamePassword = "Username or password is incorrect";

        public const string UserNotFound = "User with such username was not found";

        public const string ProvidedPasswordIsIncorrect = "The provided password is incorrect";

        public const string InvalidOperation = "Invalid operation";

        public const string ValueCannotBeEmpty = "Value cannot be empty or whitespace only string.";

        public const string InvalidPasswordHash = "Invalid length of password hash (64 bytes expected).";

        public const string InvalidPasswordSalt = "Invalid length of password salt (128 bytes expected).";
    }
}
