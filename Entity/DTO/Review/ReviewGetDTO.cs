namespace Entity.DTO.Review;

public class ReviewGetDTO
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public string UserAvatar { get; set; } = default!;
    public string UserFirstName { get; set; } = default!;
    public string UserLastName { get; set; } = default!;
    public DateTime CreatedDate { get; set; }
    public double GivenRating { get; set; }
    public string Comment { get; set; } = default!;
}
