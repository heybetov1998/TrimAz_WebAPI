namespace Entity.DTO.User;

public class UserRoleGetDTO
{
    public UserRoleGetDTO()
    {
        Id = default!;
        FirstName = default!;
        LastName = default!;
        UserName = default!;
        Email = default!;
        Token = default!;
        Avatar = default!;
        RoleNames = new HashSet<string>();
    }
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public ICollection<string> RoleNames { get; set; }
    public string Token { get; set; }
    public string Avatar { get; set; }
}
