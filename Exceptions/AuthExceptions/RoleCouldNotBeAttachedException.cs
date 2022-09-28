namespace Exceptions.AuthExceptions;

public class RoleCouldNotBeAttachedException:Exception
{
    private readonly static string _message = "Role could not be attached";
    public RoleCouldNotBeAttachedException() : base(_message) { }
}
