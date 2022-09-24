using Business.Services;
using Entity.DTO.Barbershop;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TrimAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarbershopsController : ControllerBase
    {
        private readonly IBarbershopService _barbershopService;

        public BarbershopsController(IBarbershopService barbershopService)
        {
            _barbershopService = barbershopService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var datas = await _barbershopService.GetAllAsync();

                List<BarbershopGetDTO> barbershops = new List<BarbershopGetDTO>();

                foreach (var data in datas)
                {
                    BarbershopGetDTO barbershopGetDTO = new BarbershopGetDTO();

                    barbershopGetDTO.Id = data.Id;
                    barbershopGetDTO.Name = data.Name;
                    barbershopGetDTO.AfterPrice = "-dən başlayaraq";

                    double price = double.MaxValue;
                    foreach (var barber in data.Barbers)
                    {
                        foreach (var barberService in barber.BarberServices)
                        {
                            if (barberService.ServiceDetail.Price < price)
                            {
                                price = barberService.ServiceDetail.Price;
                            }
                        }
                    }

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
    }
}
