using Microsoft.AspNetCore.Http;

namespace Entity.DTO.Seller;

public class SellerUpdateDTO
{
    public string Id { get; set; } = default!;
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public IFormFile? AvatarImage { get; set; }

}
