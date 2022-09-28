namespace Exceptions.AuthExceptions
{
    public class UserCouldNotBeCreatedException : Exception
    {
        private readonly static string _message = "User could not be created";
        public UserCouldNotBeCreatedException() : base(_message) { }
    }
}
