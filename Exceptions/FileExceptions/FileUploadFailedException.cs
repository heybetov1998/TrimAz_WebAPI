namespace Exceptions.FileExceptions;

public class FileUploadFailedException : Exception
{
    private const string message = "Error while uploading file";

    public FileUploadFailedException() : base(message) { }
}
