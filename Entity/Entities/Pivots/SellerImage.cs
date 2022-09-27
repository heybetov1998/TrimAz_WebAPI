using Entity.Base;
using Entity.Identity;

namespace Entity.Entities.Pivots
{
    public class SellerImage : IEntity
    {
        public SellerImage()
        {
            Seller = new();
            Image = new();
        }

        public int Id { get; set; }
        public bool IsAvatar { get; set; }
        public string SellerId { get; set; } = default!;
        public int ImageId { get; set; }
        public Seller Seller { get; set; }
        public Image Image { get; set; }
    }
}
