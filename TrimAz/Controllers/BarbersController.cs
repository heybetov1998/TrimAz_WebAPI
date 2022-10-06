using Business.Services;
using Entity.DTO.Barber;
using Entity.DTO.Image;
using Entity.DTO.Review;
using Entity.DTO.Service;
using Entity.DTO.Video;
using Entity.Entities;
using Entity.Identity;
using Exceptions.DataExceptions;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TrimAz.Commons;

namespace TrimAz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BarbersController : ControllerBase
{
    private readonly IBarberService _barberService;
    private readonly IReviewService _reviewService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IBarbershopService _barbershopService;

    public BarbersController(IBarberService barberService, UserManager<AppUser> userManager,
        IBarbershopService barbershopService, IReviewService reviewService)
    {
        _barberService = barberService;
        _userManager = userManager;
        _barbershopService = barbershopService;
        _reviewService = reviewService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(string id)
    {
        try
        {
            var data = await _barberService.GetAsync(id);

            BarberDetailGetDTO barber = new()
            {
                FirstName = data.FirstName,
                LastName = data.LastName,
            };

            //Avatar
            barber.Avatar = "profile-picture.png";
            foreach (var userImage in data.UserImages)
            {
                if (userImage.IsAvatar)
                {
                    barber.Avatar = userImage.Image.Name;
                    break;
                }
            }

            //StarRating
            List<double> ratings = new();
            List<Review> reviews = await _reviewService.GetAllAsync();
            List<ReviewGetDTO> reviewDTOs = new();
            foreach (Review review in reviews)
            {
                if (review.BarberId == data.Id)
                {
                    ReviewGetDTO reviewDTO = new()
                    {
                        Id = review.Id,
                        Comment = review.Message,
                        CreatedDate = review.CreatedDate,
                        GivenRating = review.GivenRating,
                        UserId = review.User.Id,
                        UserFirstName = review.User.FirstName,
                        UserLastName = review.User.LastName
                    };

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

                    ratings.Add(review.GivenRating);
                    reviewDTOs.Add(reviewDTO);
                }
            }
            barber.StarRating = ratings.Count > 0 ? Math.Round(ratings.Average(), 1) : 0;
            barber.Reviews = reviewDTOs;

            //Images
            foreach (var userImage in data.UserImages)
            {
                if (!userImage.IsAvatar)
                {
                    ImageGetDTO imageGetDTO = new();

                    imageGetDTO.Name = userImage.Image.Name;
                    imageGetDTO.Alt = imageGetDTO.Name;

                    barber.Images.Add(imageGetDTO);
                }
            }

            //Services
            foreach (var userService in data.UserServices)
            {
                ServiceTimeGetDTO serviceTimeGetDTO = new();

                serviceTimeGetDTO.Id = userService.Service.Id;
                serviceTimeGetDTO.Name = userService.Service.Name;
                //serviceTimeGetDTO.Time = barberService.ServiceDetail.Time;
                serviceTimeGetDTO.Price = userService.ServiceDetail.Price;

                barber.Services.Add(serviceTimeGetDTO);
            }

            //Videos
            foreach (var video in data.Videos)
            {
                VideoGetDTO videoGetDTO = new();

                videoGetDTO.Id = video.Id;
                videoGetDTO.YoutubeId = video.YoutubeLink.Remove(0, 32);

                barber.Videos.Add(videoGetDTO);
            }

            return Ok(barber);
        }
        catch (EntityCouldNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response(code: 4001, ex.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response(code: 4001, ex.Message));
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync(int? take)
    {

        take ??= int.MaxValue;

        try
        {
            List<BarberGetDTO> barbers = new List<BarberGetDTO>();

            List<AppUser> datas = await _barberService.GetAllAsync((int)take);

            foreach (AppUser data in datas)
            {
                BarberGetDTO barber = new()
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName,
                };

                //ImageName
                barber.ImageName = "profile-picture.png";
                foreach (var userImage in data.UserImages)
                {
                    if (userImage.IsAvatar)
                    {
                        barber.ImageName = userImage.Image.Name;
                        break;
                    }
                }

                //StarRating
                List<double> ratings = new();
                List<Review> reviews = await _reviewService.GetAllAsync();
                foreach (Review review in reviews)
                {
                    if (review.BarberId == data.Id)
                    {
                        ratings.Add(review.GivenRating);
                    }
                }
                barber.StarRating = ratings.Count > 0 ? Math.Round(ratings.Average(), 1) : 0;

                barbers.Add(barber);
            }

            return Ok(barbers);
        }
        catch (EntityCouldNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response(code: 4001, ex.Message));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new Response(code: 4001, ex.Message));
        }
    }

    [HttpPost]
    public IActionResult CreateAsync(BarberPostDTO barberPostDTO)
    {
        if (!ModelState.IsValid)
        {
            DataAnnotationNotListenedException ex = new();
            return StatusCode(StatusCodes.Status405MethodNotAllowed, new Response(4014, ex.Message));
        }

        //Barber barber = new();

        //barber.FirstName = barberPostDTO.FirstName;
        //barber.LastName = barberPostDTO.LastName;
        //barber.Email = barberPostDTO.Email;
        //barber.UserName = barberPostDTO.UserName;
        //barber.BarbershopId = barberPostDTO.BarbershopId;

        //await _userManager.CreateAsync(barber, barberPostDTO.Password);

        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(string id, BarberUpdateDTO barberUpdateDTO)
    {
        AppUser barber = await _userManager.FindByIdAsync(barberUpdateDTO.Id);

        if (barber == null)
        {
            return BadRequest(new { statusCode = 404, message = "User not found" });
        }

        barber.FirstName = barberUpdateDTO.FirstName;
        barber.LastName = barberUpdateDTO.LastName;

        await _userManager.UpdateAsync(barber);

        return Ok(new { statusCode = 200, message = "Barber updated successfully" });
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
}
