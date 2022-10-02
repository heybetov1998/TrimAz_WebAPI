namespace Entity.DTO.User;

public class UserRoleGetDTO
{
    public UserRoleGetDTO()
    {
        FirstName = default!;
        LastName = default!;
        RoleNames = new HashSet<string>();
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<string> RoleNames { get; set; }
}
