using Business.Services;
using Entity.DTO.Review;
using Entity.Entities;
using Entity.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TrimAz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewsController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IReviewService _reviewService;

    public ReviewsController(UserManager<AppUser> userManager, IReviewService reviewService)
    {
        _userManager = userManager;
        _reviewService = reviewService;
    }

    [HttpPost("barber")]
    public async Task<IActionResult> CreateAsync(ReviewBarberCreateDTO reviewCreateDTO)
    {
        AppUser user = await _userManager.FindByIdAsync(reviewCreateDTO.UserId);

        Review review = new()
        {
            CreatedDate = DateTime.UtcNow.AddHours(4),
            BarberId = reviewCreateDTO.BarberId,
            UserId = reviewCreateDTO.UserId,
            User = user,
            GivenRating = reviewCreateDTO.Rating,
            Message = reviewCreateDTO.Comment
        };

        await _reviewService.CreateAsync(review);

        return Ok(new { statusCode = 200, message = "Review added successfully" });
    }

    [HttpPost("product")]
    public async Task<IActionResult> CreateAsync(ReviewProductCreateDTO reviewCreateDTO)
    {
        AppUser user = await _userManager.FindByIdAsync(reviewCreateDTO.UserId);

        Review review = new()
        {
            CreatedDate = DateTime.UtcNow.AddHours(4),
            ProductId = reviewCreateDTO.ProductId,
            UserId = reviewCreateDTO.UserId,
            User = user,
            GivenRating = reviewCreateDTO.Rating,
            Message = reviewCreateDTO.Comment
        };

        await _reviewService.CreateAsync(review);

        return Ok(new { statusCode = 200, message = "Review added successfully" });
    }
}
