using Business.Services;
using DAL.Context;
using Entity.DTO.Product;
using Entity.DTO.Productı;
using Entity.DTO.Review;
using Entity.Entities;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Mvc;
using TrimAz.Commons;

namespace TrimAz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly AppDbContext _context;
    private readonly IReviewService _reviewService;

    public ProductsController(IProductService productService, IReviewService reviewService, AppDbContext context)
    {
        _productService = productService;
        _reviewService = reviewService;
        _context = context;
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
            product.Seller.Id = data.User.Id;
            product.Seller.FirstName = data.User.FirstName;
            product.Seller.LastName = data.User.LastName;

            // Seller Avatar
            product.Seller.Image.Name = "profile-picture.png";
            foreach (var sellerImage in data.User.UserImages)
            {
                if (sellerImage.IsAvatar)
                {
                    product.Seller.Image.Name = sellerImage.Image.Name;
                    break;
                }
            }
            product.Seller.Image.Alt = product.Seller.Image.Name;

            //Main image
            product.MainImage = "no-image.png";
            foreach (var productImage in data.ProductImages)
            {
                if (productImage.IsMain)
                {
                    product.MainImage = productImage.Image.Name;
                    break;
                }
            }

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
            List<Review> reviews = await _reviewService.GetAllAsync();
            foreach (Review review in reviews)
            {
                if (data.Id == review.ProductId)
                {
                    ReviewGetDTO reviewDTO = new();

                    reviewDTO.Id = review.Id;
                    reviewDTO.UserId = review.User.Id;
                    reviewDTO.UserFirstName = review.User.FirstName;
                    reviewDTO.UserLastName = review.User.LastName;
                    reviewDTO.CreatedDate = review.CreatedDate;
                    reviewDTO.GivenRating = review.GivenRating;
                    reviewDTO.Comment = review.Message;

                    //Review User Avatar
                    reviewDTO.UserAvatar = "profile-picture.png";
                    foreach (var userImage in review.User.UserImages)
                    {
                        if (userImage.IsAvatar)
                        {
                            reviewDTO.UserAvatar = userImage.Image.Name;
                            break;
                        }
                    }
                    product.Reviews.Add(reviewDTO);
                }
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

                productGetDTO.Image.Name = "no-image.png";
                foreach (var productImage in data.ProductImages)
                {
                    if (productImage.IsMain)
                    {
                        productGetDTO.Image.Name = productImage.Image.Name;
                        break;
                    }
                }
                productGetDTO.Image.Alt = productGetDTO.Image.Name;

                productGetDTO.Seller.Id = data.User.Id;
                productGetDTO.Seller.FirstName = data.User.FirstName;
                productGetDTO.Seller.LastName = data.User.LastName;

                productGetDTO.Seller.Image.Name = "profile-picture.png";
                foreach (var sellerImage in data.User.UserImages)
                {
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

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] ProductCreateDTO productCreateDTO)
    {
        Product product = new()
        {
            Title = productCreateDTO.Title,
            Content = productCreateDTO.Content,
            Price = productCreateDTO.Price,
            CreatedDate = DateTime.UtcNow.AddHours(4),
            UserId = productCreateDTO.UserId,
        };
        await _productService.CreateAsync(product);

        await _productService.UploadAsync(product, productCreateDTO.Images);

        return Ok(new { statusCode = 200, message = "Product created successfully" });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, ProductUpdateDTO productUpdateDTO)
    {
        Product product = await _productService.GetAsync(productUpdateDTO.Id);

        product.Title = productUpdateDTO.Title;
        product.Content = productUpdateDTO.Content;
        product.Price = productUpdateDTO.Price;

        await _productService.UpdateAsync(product.Id, product);

        return Ok(new { statusCode = 200, message = "Product updated successfully" });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _productService.DeleteAsync(id);
        return Ok(new { statusCode = 200, message = "Product deleted successfully" });
    }
}
