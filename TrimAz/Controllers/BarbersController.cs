using Business.Services;
using DAL.Context;
using Entity.DTO.Barber;
using Entity.DTO.Image;
using Entity.DTO.Review;
using Entity.DTO.Service;
using Entity.DTO.Time;
using Entity.DTO.Video;
using Entity.Entities;
using Entity.Entities.Pivots;
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
    private readonly ITimeService _timeService;

    public BarbersController(IBarberService barberService, UserManager<AppUser> userManager,
        IBarbershopService barbershopService, IReviewService reviewService, ITimeService timeService)
    {
        _barberService = barberService;
        _userManager = userManager;
        _barbershopService = barbershopService;
        _reviewService = reviewService;
        _timeService = timeService;
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

            //Times
            List<Time> times = await _timeService.GetAllAsync();

            //Remove reserved
            List<Time> uTime = new();

            foreach (var time in times)
            {
                if (data.UserTimes.Count > 0)
                {
                    foreach (var userTime in data.UserTimes)
                    {
                        if (time.Id != userTime.Time.Id)
                        {
                            if (!uTime.Contains(time))
                            {
                                uTime.Add(time);
                            }
                        }
                        else
                        {
                            if (uTime.Contains(time))
                            {
                                uTime.Remove(time);
                            }
                            break;
                        }
                    }
                }
                else
                {
                    uTime = times;
                    break;
                }
            }

            foreach (var ut in uTime)
            {
                TimeGetDTO timeGetDTO = new()
                {
                    Id = ut.Id,
                    Range = ut.Range
                };

                barber.Times.Add(timeGetDTO);
            }

            //BarbershopId
            foreach (var userBarbershop in data.UserBarbershops)
            {
                barber.BarbershopId = userBarbershop.Barbershop.Id;
                break;
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

                data.StarRating = barber.StarRating;
                await _userManager.UpdateAsync(data);

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
    public async Task<IActionResult> UpdateAsync(string id, [FromForm] BarberUpdateDTO barberUpdateDTO)
    {
        AppUser barber = await _barberService.GetAsync(barberUpdateDTO.Id);

        if (barber == null)
        {
            return BadRequest(new { statusCode = 404, message = "User not found" });
        }

        barber.FirstName = barberUpdateDTO.FirstName;
        barber.LastName = barberUpdateDTO.LastName;

        foreach (var userBarbershop in barber.UserBarbershops)
        {
            barber.UserBarbershops.Remove(userBarbershop);
        }

        if (barberUpdateDTO.BarbershopId != 0)
        {
            UserBarbershop userBarbershop = new()
            {
                User = barber,
                UserId = barber.Id,
                BarbershopId = barberUpdateDTO.BarbershopId,
                Barbershop = await _barbershopService.GetAsync(barberUpdateDTO.BarbershopId)
            };
            barber.UserBarbershops.Add(userBarbershop);
        }

        if (barberUpdateDTO.AvatarImage is not null)
            await _barberService.UploadAsync(barber, barberUpdateDTO.AvatarImage, true);

        if (barberUpdateDTO.PortfolioImages.Count > 0)
            await _barberService.UploadAsync(barber, barberUpdateDTO.PortfolioImages);

        await _userManager.UpdateAsync(barber);

        return Ok(new { statusCode = 200, message = "Barber updated successfully" });
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }

    [HttpPost("{userId}")]
    public async Task<IActionResult> ReserveAsync(string userId, int timeId)
    {
        AppUser user = await _userManager.FindByIdAsync(userId);
        Time time = await _timeService.GetAsync(timeId);

        UserTime userTime = new()
        {
            Time = time,
            TimeId = timeId,
            User = user,
            UserId = userId,
            IsReserved = true,
            IsEndTime = false,
            IsStartTime = false
        };
        user.UserTimes.Add(userTime);

        await _userManager.UpdateAsync(user);

        //return Ok(new { userId = userId, timeId = timeId });
        return Ok(new { statusCode = 200, message = "Reserved successfully" });
    }

    [HttpGet("Filtered")]
    public async Task<IActionResult> GetFiltered(int serviceId, int timeId)
    {
        try
        {
            List<BarberGetDTO> barbers = new List<BarberGetDTO>();

            List<AppUser> datas = await _barberService.GetAllAsync();

            foreach (AppUser data in datas)
            {
                bool hasService = false;
                bool hasTime = false;

                foreach (var userService in data.UserServices)
                {
                    if (userService.Service.Id == serviceId)
                    {
                        hasService = true;
                        break;
                    }
                }

                foreach (var userTime in data.UserTimes)
                {
                    if (userTime.Time.Id != timeId)
                    {
                        hasTime = true;
                    }
                    else
                    {
                        hasTime = false;
                        break;
                    }
                }

                if (hasTime && hasService)
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

                    data.StarRating = barber.StarRating;
                    await _userManager.UpdateAsync(data);

                    barbers.Add(barber);
                }
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

    [HttpGet("ByPrice")]
    public async Task<IActionResult> GetByPrice(double minPrice = 0, double maxPrice = double.MaxValue)
    {
        try
        {
            List<BarberGetDTO> barbers = new List<BarberGetDTO>();

            List<AppUser> datas = await _barberService.GetAllAsync();

            foreach (AppUser data in datas)
            {
                bool isValidPrice = false;

                foreach (var userService in data.UserServices)
                {
                    if (userService.ServiceDetail.Price >= minPrice && userService.ServiceDetail.Price <= maxPrice)
                    {
                        isValidPrice = true;
                        break;
                    }
                }

                if (isValidPrice)
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

                    data.StarRating = barber.StarRating;
                    await _userManager.UpdateAsync(data);

                    barbers.Add(barber);
                }
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

    [HttpGet("Search")]
    public async Task<IActionResult> GetBySearch(string search)
    {
        try
        {
            List<BarberGetDTO> barbers = new List<BarberGetDTO>();

            List<AppUser> datas = await _barberService.GetAllAsync();
            string[] splits = search.Split(" ");

            foreach (AppUser data in datas)
            {
                bool isValid = false;

                foreach (var split in splits)
                {
                    if (data.FirstName.ToLower().Contains(split.ToLower()) ||
                        data.LastName.ToLower().Contains(split.ToLower()))
                    {
                        isValid = true;
                        break;
                    }
                }

                if (isValid)
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

                    data.StarRating = barber.StarRating;
                    await _userManager.UpdateAsync(data);

                    barbers.Add(barber);
                }
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
}
