namespace Entity.DTO.User;

public class UserSettingsDTO
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Avatar { get; set; }

    public UserSettingsDTO()
    {
        Id = default!;
        FirstName = default!;
        LastName = default!;
        UserName = default!;
        PhoneNumber = default!;
        Email = default!;
        Avatar = default!;
    }
}
