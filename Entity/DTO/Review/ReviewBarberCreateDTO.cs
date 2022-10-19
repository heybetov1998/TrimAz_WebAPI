namespace Entity.DTO.Review;

public class ReviewBarberCreateDTO
{
    public int Rating { get; set; }
    public string Comment { get; set; }
    public string UserId { get; set; }
    public string BarberId { get; set; }

    public ReviewBarberCreateDTO()
    {
        Comment = default!;
    }
}
