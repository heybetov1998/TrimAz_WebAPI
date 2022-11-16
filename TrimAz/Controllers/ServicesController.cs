using Business.Services;
using Entity.DTO.Service;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Mvc;
using TrimAz.Commons;

namespace TrimAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IBarberService _barberService;

        public ServicesController(IServiceService serviceService, IBarberService barberService)
        {
            _serviceService = serviceService;
            _barberService = barberService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int? take)
        {
            take ??= int.MaxValue;

            try
            {
                var datas = await _serviceService.GetAllAsync(take: (int)take);

                List<ServiceGetDTO> services = new List<ServiceGetDTO>();

                foreach (var data in datas)
                {
                    ServiceGetDTO serviceGetDTO = new ServiceGetDTO();

                    serviceGetDTO.Id = data.Id;
                    serviceGetDTO.Name = data.Name;

                    services.Add(serviceGetDTO);
                }

                return Ok(services);
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

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] ServiceUpdateDTO serviceUpdateDTO)
        {
            var barber =await _barberService.GetAsync(serviceUpdateDTO.BarberId);


            return Ok(serviceUpdateDTO);
        }
    }
}
