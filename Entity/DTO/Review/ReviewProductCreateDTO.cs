namespace Entity.DTO.Review;

public class ReviewProductCreateDTO
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public string UserId { get; set; }
    public int ProductId { get; set; }

    public ReviewProductCreateDTO()
    {
        Comment = default!;
    }
}
