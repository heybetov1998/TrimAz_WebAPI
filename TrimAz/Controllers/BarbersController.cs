using Business.Services;
using Entity.DTO.Barber;
using Entity.DTO.Image;
using Entity.DTO.Review;
using Entity.DTO.Service;
using Entity.DTO.Video;
using Entity.Entities.Pivots;
using Entity.Identity;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Mvc;
using TrimAz.Commons;

namespace TrimAz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BarbersController : ControllerBase
{
    private readonly IBarberService _barberService;

    public BarbersController(IBarberService barberService)
    {
        _barberService = barberService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(string id)
    {
        try
        {
            var data = await _barberService.GetAsync(id);

            List<double> ratings = new();
            BarberDetailGetDTO barber = new();

            barber.FirstName = data.FirstName;
            barber.LastName = data.LastName;

            //Avatar
            barber.Avatar = "no-image.png";
            foreach (var barberImage in data.BarberImages)
            {
                if (barberImage.IsAvatar)
                {
                    barber.Avatar = barberImage.Image.Name;
                    break;
                }
            }

            //Rating
            foreach (var userBarber in data.UserBarbers)
            {
                ratings.Add(userBarber.StarRating);
            }
            barber.StarRating = ratings.Count > 0 ? Math.Round(ratings.Average(), 1) : 0;

            //Images
            foreach (var barberImage in data.BarberImages)
            {
                if (!barberImage.IsAvatar)
                {
                    ImageGetDTO imageGetDTO = new();

                    imageGetDTO.Name = barberImage.Image.Name;
                    imageGetDTO.Alt = imageGetDTO.Name;

                    barber.Images.Add(imageGetDTO);
                }
            }

            //Services
            foreach (var barberService in data.BarberServices)
            {
                ServiceTimeGetDTO serviceTimeGetDTO = new();

                serviceTimeGetDTO.Id = barberService.Service.Id;
                serviceTimeGetDTO.Name = barberService.Service.Name;
                serviceTimeGetDTO.Time = barberService.ServiceDetail.Time;
                serviceTimeGetDTO.Price = barberService.ServiceDetail.Price;

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

            //Reviews
            foreach (var userBarber in data.UserBarbers)
            {
                ReviewGetDTO review = new();

                review.Id = userBarber.Id;
                review.UserId = userBarber.User.Id;
                review.UserFirstName = userBarber.User.FirstName;
                review.UserLastName = userBarber.User.LastName;
                review.CreatedDate = userBarber.CreatedDate;
                review.GivenRating = userBarber.StarRating;
                review.Comment = userBarber.Message;

                //Review User Avatar
                review.UserAvatar = "profile-picture.png";
                foreach (var userImage in userBarber.User.UserImages)
                {
                    if (userImage.IsAvatar)
                    {
                        review.UserAvatar = userImage.Image.Name;
                        break;
                    }
                }

                barber.Reviews.Add(review);
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
        List<BarberGetDTO> barbers = new List<BarberGetDTO>();

        take ??= int.MaxValue;

        try
        {
            var datas = await _barberService.GetAllAsync(take: (int)take);

            foreach (Barber data in datas)
            {
                List<double> ratings = new List<double>();
                BarberGetDTO barberGetDTO = new BarberGetDTO()
                {
                    Id = data.Id,
                    FirstName = data.FirstName,
                    LastName = data.LastName
                };

                foreach (var userBarber in data.UserBarbers)
                {
                    ratings.Add(userBarber.StarRating);
                }

                barberGetDTO.ImageName = "profile-picture.png";

                foreach (var barberImage in data.BarberImages)
                {
                    if (barberImage.IsAvatar)
                    {
                        barberGetDTO.ImageName = barberImage.Image.Name;
                        break;
                    }
                }

                barberGetDTO.StarRating = ratings.Count > 0 ? Math.Round(ratings.Average(), 1) : 0;

                barbers.Add(barberGetDTO);
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
    public IActionResult Create()
    {
        return Ok();
    }

    [HttpPut]
    public IActionResult Update()
    {
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete()
    {
        return Ok();
    }
}
