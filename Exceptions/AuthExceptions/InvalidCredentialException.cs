namespace Exceptions.AuthExceptions;

public class InvalidCredentialException : Exception
{
    private readonly static string _message = "Credentials are invalid";
    public InvalidCredentialException() : base(_message) { }
}
