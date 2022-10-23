namespace Entity.DTO.Feedback;

public class FeedbackCreateDTO
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }

    public FeedbackCreateDTO()
    {
        FullName = default!;
        Email = default!;
        Message = default!;
    }
}
