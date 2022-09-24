using Entity.DTO.Image;

namespace Entity.DTO.User
{
    public class UserGetDTO
    {
        public UserGetDTO()
        {
            Image = new();
        }

        public string Id { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public ImageGetDTO Image { get; set; }
    }
}
