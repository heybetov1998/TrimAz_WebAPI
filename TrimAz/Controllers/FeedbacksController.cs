using DAL.Context;
using Entity.DTO.Feedback;
using Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TrimAz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FeedbacksController : ControllerBase
{
    private readonly AppDbContext _context;

    public FeedbacksController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var datas = await _context.Feedbacks.ToListAsync();
        return Ok(datas);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] FeedbackCreateDTO feedbackCreateDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Invalid input");
        }

        Feedback feedback = new()
        {
            Message = feedbackCreateDTO.Message,
            Email = feedbackCreateDTO.Email,
            FullName = feedbackCreateDTO.FullName,
            CreatedDate = DateTime.UtcNow.AddHours(4)
        };

        await _context.Feedbacks.AddAsync(feedback);
        await _context.SaveChangesAsync();

        return Ok(new { statusCode = 200, message = "Feedback successfully added" });
    }
}
