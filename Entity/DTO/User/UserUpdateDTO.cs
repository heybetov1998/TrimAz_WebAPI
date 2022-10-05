using Microsoft.AspNetCore.Http;

namespace Entity.DTO.User;

public class UserUpdateDTO
{
    public string Email { get; set; }
    public string UserName { get; set; }
    //public IFormFile UploadedAvatar { get; set; }

    public UserUpdateDTO()
    {
        Email = default!;
        UserName = default!;
        //UploadedAvatar = null!;
    }
}
