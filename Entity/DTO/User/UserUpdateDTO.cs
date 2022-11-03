using Microsoft.AspNetCore.Http;

namespace Entity.DTO.User;

public class UserUpdateDTO
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public IFormFile? AvatarImage { get; set; }

    public UserUpdateDTO()
    {
        Id = default!;
        FirstName = default!;
        LastName = default!;
        PhoneNumber = default!;
    }
}
