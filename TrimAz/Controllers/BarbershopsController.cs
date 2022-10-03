using Business.Auth;
using Business.Services;
using Entity.DTO.Barbershop;
using Entity.DTO.Location;
using Entity.Entities;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using TrimAz.Commons;

namespace TrimAz.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BarbershopsController : ControllerBase
{
    private readonly IBarbershopService _barbershopService;
    private readonly IJwtUtils _jwtUtils;

    public BarbershopsController(IBarbershopService barbershopService, IJwtUtils jwtUtils)
    {
        _barbershopService = barbershopService;
        _jwtUtils = jwtUtils;
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
            //foreach (var barber in data.Barbers)
            //{
            //    BarberGetDTO barberGetDTO = new();
            //    List<double> ratings = new();

            //    barberGetDTO.Id = barber.Id;
            //    barberGetDTO.FirstName = barber.FirstName;
            //    barberGetDTO.LastName = barber.LastName;

            //    //StarRating
            //    foreach (var userBarber in barber.UserBarbers)
            //    {
            //        ratings.Add(userBarber.StarRating);
            //    }
            //    barberGetDTO.StarRating = ratings.Count > 0 ? Math.Round(ratings.Average(), 1) : 0;

            //    //Avatar Image
            //    barberGetDTO.ImageName = "user-profile.png";
            //    foreach (var barberImage in barber.BarberImages)
            //    {
            //        if (barberImage.IsAvatar)
            //        {
            //            barberGetDTO.ImageName = barberImage.Image.Name;
            //            break;
            //        }
            //    }

            //    barbershop.Barbers.Add(barberGetDTO);
            //}

            ////Services
            //foreach (var barber in data.Barbers)
            //{
            //    foreach (var barberService in barber.BarberServices)
            //    {
            //        ServiceGetDTO service = new();

            //        service.Id = barberService.Service.Id;
            //        service.Name = barberService.Service.Name;

            //        barbershop.Services.Add(service);
            //    }
            //}
            //barbershop.Services = barbershop.Services.DistinctBy(n => n.Id).ToList();

            //Locations
            foreach (var barbershopLocation in data.BarbershopLocations)
            {
                LocationGetDTO location = new();

                location.Latitude = barbershopLocation.Location.Latitude;
                location.Longtitude = barbershopLocation.Location.Longtitude;

                barbershop.Locations.Add(location);
            }

            //Reviews
            //Reviews
            //foreach (var barber in data.Barbers)
            //{
            //    foreach (var userBarber in barber.UserBarbers)
            //    {
            //        ReviewGetDTO review = new();

            //        review.Id = userBarber.Id;
            //        review.UserId = userBarber.User.Id;
            //        review.UserFirstName = userBarber.User.FirstName;
            //        review.UserLastName = userBarber.User.LastName;
            //        review.CreatedDate = userBarber.CreatedDate;
            //        review.GivenRating = userBarber.StarRating;
            //        review.Comment = userBarber.Message;

            //        //Review User Avatar
            //        review.UserAvatar = "profile-picture.png";
            //        foreach (var userImage in userBarber.User.UserImages)
            //        {
            //            if (userImage.IsAvatar)
            //            {
            //                review.UserAvatar = userImage.Image.Name;
            //                break;
            //            }
            //        }

            //        barbershop.Reviews.Add(review);
            //    }
            //}

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
                //foreach (var barber in data.Barbers)
                //{
                //    foreach (var barberService in barber.BarberServices)
                //    {
                //        if (barberService.ServiceDetail.Price < price)
                //        {
                //            price = barberService.ServiceDetail.Price;
                //        }
                //    }
                //}

                barbershopGetDTO.Price = Math.Round(price);

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
                barbershopGetDTO.Location = "testtest";

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
    //[Authorize(Roles = "Admin,Owner")]
    public async Task<IActionResult> CreateAsync(BarbershopPostDTO barbershopPostDTO)
    {
        try
        {
            var bearerToken = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

            //if (_jwtUtils.ValidateToken(bearerToken) is null)
            //{
            //    return StatusCode(StatusCodes.Status403Forbidden);
            //}

            Barbershop barbershop = new()
            {
                Name = barbershopPostDTO.Name
            };

            await _barbershopService.CreateAsync(barbershop);
            return Ok(new { statusCode = 200, message = "Barbershop added successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status401Unauthorized, ex.Message);
        }
    }
}