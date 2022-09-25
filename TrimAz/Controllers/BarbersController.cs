﻿using Business.Services;
using Entity.DTO.Barber;
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

                if (ratings.Count > 0)
                    barberGetDTO.StarRating = Math.Round(ratings.Average(), 1);
                else
                    barberGetDTO.StarRating = 0;

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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAsync(string id)
    {
        try
        {
            var data = await _barberService.GetAsync(id);
            return Ok(data);
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