using Microsoft.AspNetCore.Http;

namespace Entity.DTO.Owner;

public class OwnerUpdateDTO
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public IFormFile? AvatarImage { get; set; }

    public OwnerUpdateDTO()
    {
        Id = default!;
        FirstName = default!;
        LastName = default!;
    }
}
