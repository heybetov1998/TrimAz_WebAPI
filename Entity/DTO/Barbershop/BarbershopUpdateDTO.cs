using Microsoft.AspNetCore.Http;

namespace Entity.DTO.Barbershop
{
    public class BarbershopUpdateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<IFormFile> Images { get; set; }

        public BarbershopUpdateDTO()
        {
            Name = default!;
            Images = new HashSet<IFormFile>();
        }
    }
}
