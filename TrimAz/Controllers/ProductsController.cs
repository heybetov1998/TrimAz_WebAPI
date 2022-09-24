using Business.Services;
using Entity.DTO.Product;
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var datas = await _productService.GetAllAsync();

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
