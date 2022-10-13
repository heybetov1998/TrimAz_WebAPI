using Entity.DTO.Image;

namespace Entity.DTO.Seller;

public class SellerGetDTO
{
    public SellerGetDTO()
    {
        Image = new();
    }

    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string PhoneNumber { get; set; } = default!;
    public ImageGetDTO Image { get; set; }
}
