using Business.Services;
using Entity.DTO.Product;
using Entity.DTO.Productı;
using Entity.DTO.Review;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Mvc;
using TrimAz.Commons;

namespace TrimAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                var data = await _productService.GetAsync(id);

                ProductDetailGetDTO product = new();

                // Title // Price // Content
                product.Title = data.Title;
                product.Price = data.Price;
                product.Content = data.Content;

                // Seller
                product.Seller.Id = data.Seller.Id;
                product.Seller.FirstName = data.Seller.FirstName;
                product.Seller.LastName = data.Seller.LastName;

                // Seller Avatar
                product.Seller.Image.Name = "profile-picture.png";
                foreach (var sellerImage in data.Seller.SellerImages)
                {
                    if (sellerImage.IsAvatar)
                    {
                        product.Seller.Image.Name = sellerImage.Image.Name;
                        break;
                    }
                }
                product.Seller.Image.Alt = product.Seller.Image.Name;

                // Product Images
                foreach (var productImage in data.ProductImages)
                {
                    if (productImage.IsMain)
                    {
                        product.MainImage = productImage.Image.Name;
                        continue;
                    }
                    product.Images.Add(productImage.Image.Name);
                }

                // Product Reviews
                foreach (var userProduct in data.UserProducts)
                {
                    ReviewGetDTO review = new();

                    review.Id = userProduct.Id;
                    review.UserId = userProduct.User.Id;
                    review.UserFirstName = userProduct.User.FirstName;
                    review.UserLastName = userProduct.User.LastName;
                    review.CreatedDate = userProduct.CreatedDate;
                    review.GivenRating = userProduct.StarRating;
                    review.Comment = userProduct.Message;

                    //Review User Avatar
                    review.UserAvatar = "profile-picture.png";
                    foreach (var userImage in userProduct.User.UserImages)
                    {
                        if (userImage.IsAvatar)
                        {
                            review.UserAvatar = userImage.Image.Name;
                            break;
                        }
                    }

                    product.Reviews.Add(review);
                }

                return Ok(product);
            }
            catch (EntityCouldNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4001, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4001, ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int? take)
        {
            take ??= int.MaxValue;
            try
            {
                var datas = await _productService.GetAllAsync(take: (int)take);

                List<ProductGetDTO> products = new List<ProductGetDTO>();

                foreach (var data in datas)
                {
                    ProductGetDTO productGetDTO = new ProductGetDTO();

                    productGetDTO.Id = data.Id;
                    productGetDTO.Title = data.Title;
                    productGetDTO.Price = data.Price;

                    foreach (var productImage in data.ProductImages)
                    {
                        productGetDTO.Image.Name = "no-image.png";

                        if (productImage.IsMain)
                        {
                            if (productImage.Image is not null)
                            {
                                productGetDTO.Image.Name = productImage.Image.Name;
                                break;
                            }
                        }
                    }

                    productGetDTO.Image.Alt = productGetDTO.Image.Name;

                    productGetDTO.Seller.Id = data.Seller.Id;
                    productGetDTO.Seller.FirstName = data.Seller.FirstName;
                    productGetDTO.Seller.LastName = data.Seller.LastName;

                    foreach (var sellerImage in data.Seller.SellerImages)
                    {
                        productGetDTO.Seller.Image.Name = "profile-picture.png";

                        if (sellerImage.IsAvatar)
                        {
                            productGetDTO.Seller.Image.Name = sellerImage.Image.Name;
                            break;
                        }
                    }

                    productGetDTO.Seller.Image.Alt = productGetDTO.Seller.Image.Name;

                    products.Add(productGetDTO);
                }

                return Ok(products);
            }
            catch (EntityCouldNotFoundException ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4001, ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response(4001, ex.Message));
            }
        }
    }
}
