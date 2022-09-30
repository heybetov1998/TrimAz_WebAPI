namespace Exceptions.DataExceptions;

public class DataAnnotationNotListenedException : Exception
{
    private readonly static string _message = "Data annotation not listened";

    public DataAnnotationNotListenedException() : base(_message) { }
}
