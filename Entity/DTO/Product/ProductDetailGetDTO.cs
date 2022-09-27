using Entity.DTO.Review;
using Entity.DTO.User;

namespace Entity.DTO.Productı
{
    public class ProductDetailGetDTO
    {
        public ProductDetailGetDTO()
        {
            Seller = new();
            Images = new HashSet<string>();
            Reviews = new HashSet<ReviewGetDTO>();
        }

        public string Title { get; set; } = default!;
        public double Price { get; set; }
        public string Content { get; set; } = default!;
        public string MainImage { get; set; } = default!;
        public UserGetDTO Seller { get; set; }
        public ICollection<string> Images { get; set; }
        public ICollection<ReviewGetDTO> Reviews { get; set; }
    }
}
