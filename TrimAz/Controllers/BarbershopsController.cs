using Business.Jwt;
using Business.Services;
using Entity.DTO.Barber;
using Entity.DTO.Barbershop;
using Entity.DTO.Review;
using Entity.DTO.Service;
using Entity.Entities;
using Entity.Identity;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Mvc;
using TrimAz.Commons;

namespace TrimAz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BarbershopsController : ControllerBase
{
    private readonly IBarbershopService _barbershopService;
    private readonly IReviewService _reviewService;
    private readonly IJwtUtils _jwtUtils;

    public BarbershopsController(IBarbershopService barbershopService, IJwtUtils jwtUtils, IReviewService reviewService)
    {
        _barbershopService = barbershopService;
        _jwtUtils = jwtUtils;
        _reviewService = reviewService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(int id)
    {
        try
        {
            var data = await _barbershopService.GetAsync(id);

            //return Ok(data);

            BarbershopDetailGetDTO barbershop = new();

            //Name
            barbershop.Name = data.Name;

            //Images
            foreach (var barbershopImage in data.BarbershopImages)
            {
                barbershop.Images.Add(barbershopImage.Image.Name);
            }

            //Barbers
            foreach (var userBarbershop in data.UserBarbershops)
            {
                if (userBarbershop.User.RoleName == "Barber")
                {
                    AppUser barber = userBarbershop.User;
                    BarberGetDTO barberGetDTO = new();
                    barberGetDTO.Id = barber.Id;
                    barberGetDTO.FirstName = barber.FirstName;
                    barberGetDTO.LastName = barber.LastName;

                    List<Review> reviews = await _reviewService.GetAllAsync();
                    List<double> ratings = new();

                    //StarRating
                    foreach (var review in reviews)
                    {
                        if (barber.Id == review.BarberId)
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
                            barbershop.Reviews.Add(reviewDTO);
                            ratings.Add(review.GivenRating);
                        }
                    }
                    barberGetDTO.StarRating = ratings.Count > 0 ? Math.Round(ratings.Average(), 1) : 0;

                    //Avatar Image
                    barberGetDTO.ImageName = "profile-picture.png";
                    foreach (var barberImage in barber.UserImages)
                    {
                        if (barberImage.IsAvatar)
                        {
                            barberGetDTO.ImageName = barberImage.Image.Name;
                            break;
                        }
                    }

                    barbershop.Barbers.Add(barberGetDTO);

                    foreach (var barberService in barber.UserServices)
                    {
                        ServiceGetDTO service = new();

                        service.Id = barberService.Service.Id;
                        service.Name = barberService.Service.Name;

                        barbershop.Services.Add(service);
                    }
                }

            }
            barbershop.Services = barbershop.Services.DistinctBy(n => n.Id).ToList();
            barbershop.Latitude = Convert.ToDecimal(data.Latitude);
            barbershop.Longtitude = Convert.ToDecimal(data.Longtitude);

            return Ok(barbershop);
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
            var datas = await _barbershopService.GetAllAsync(take: (int)take);

            List<BarbershopGetDTO> barbershops = new List<BarbershopGetDTO>();

            foreach (var data in datas)
            {
                BarbershopGetDTO barbershopGetDTO = new BarbershopGetDTO();

                barbershopGetDTO.Id = data.Id;
                barbershopGetDTO.Name = data.Name;
                barbershopGetDTO.AfterPrice = "-dən başlayaraq";

                double price = double.MaxValue;
                foreach (var userBarbershop in data.UserBarbershops)
                {
                    foreach (var userService in userBarbershop.User.UserServices)
                    {
                        if (userService.ServiceDetail.Price < price)
                        {
                            price = userService.ServiceDetail.Price;
                        }
                    }
                }

                barbershopGetDTO.Price = price < double.MaxValue ? Math.Round(price) : 0;

                barbershopGetDTO.Image.Name = "no-image.png";
                foreach (var barbershopImage in data.BarbershopImages)
                {
                    if (barbershopImage.IsMain)
                    {
                        barbershopGetDTO.Image.Name = barbershopImage.Image.Name;
                        break;
                    }
                }
                barbershopGetDTO.Image.Alt = barbershopGetDTO.Image.Name;

                barbershops.Add(barbershopGetDTO);
            }

            return Ok(barbershops);
        }
        catch (EntityCouldNotFoundException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromForm] BarbershopPostDTO barbershopPostDTO)
    {
        //string token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

        //if (_jwtUtils.ValidateToken(token) == null)
        //{
        //    return StatusCode(StatusCodes.Status403Forbidden, new Response(StatusCodes.Status403Forbidden, "Not valid token"));
        //}

        Barbershop barbershop = new()
        {
            Name = barbershopPostDTO.Name,
            Latitude = barbershopPostDTO.Latitude.ToString(),
            Longtitude = barbershopPostDTO.Longtitude.ToString(),
            CreatedDate = DateTime.UtcNow.AddHours(4)
        };
        await _barbershopService.CreateAsync(barbershop);

        await _barbershopService.UploadAsync(barbershop, barbershopPostDTO.Images, isUpdate: false);

        return Ok(new { statusCode = 200, message = "Barbershop added successfully" });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromForm] BarbershopUpdateDTO barbershopUpdateDTO)
    {
        Barbershop barbershop = await _barbershopService.GetAsync(barbershopUpdateDTO.Id);

        barbershop.Name = barbershopUpdateDTO.Name;

        await _barbershopService.UploadAsync(barbershop, barbershopUpdateDTO.Images, isUpdate: true);
        await _barbershopService.UpdateAsync(barbershop.Id, barbershop);

        return Ok(new { statusCode = 200, message = "Barbershop updated successfully" });
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        await _barbershopService.DeleteAsync(id);
        return Ok(new { statusCode = 200, message = "Barbershop deleted successfully" });
    }
}
