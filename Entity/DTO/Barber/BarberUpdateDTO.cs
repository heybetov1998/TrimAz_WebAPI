using Microsoft.AspNetCore.Http;

namespace Entity.DTO.Barber
{
    public class BarberUpdateDTO
    {
        public string Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public IFormFile? AvatarImage { get; set; }
        public ICollection<IFormFile> PortfolioImages { get; set; }

        public BarberUpdateDTO()
        {
            PortfolioImages = new HashSet<IFormFile>();
        }
    }
}
