using Entity.Base;
using Entity.Identity;

namespace Entity.Entities
{
    public class Review : BaseEntity, IEntity
    {
        public string Message { get; set; }
        public double GivenRating { get; set; }
        public string? BarberId { get; set; }
        public string UserId { get; set; }
        public AppUser User { get; set; }

        public Review()
        {
            Message = default!;
            UserId = default!;
            User = new();
        }

    }
}
