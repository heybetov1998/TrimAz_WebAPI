using Business.Services;
using DAL.Context;
using Entity.DTO.Service;
using Entity.Entities;
using Entity.Entities.Pivots;
using Entity.Identity;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using TrimAz.Commons;

namespace TrimAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService _serviceService;
        private readonly IBarberService _barberService;
        private readonly AppDbContext _context;

        public ServicesController(IServiceService serviceService, IBarberService barberService, AppDbContext context)
        {
            _serviceService = serviceService;
            _barberService = barberService;
            _context = context;
        }

        private async Task<Service> GetAsync(int id)
        {
            var service = await _serviceService.GetAsync(id);
            return service;
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

        private async Task<ServiceDetail> CreateServiceDetailAsync(double price)
        {
            ServiceDetail serviceDetail = new ServiceDetail()
            {
                Price = price,
                CreatedDate = DateTime.UtcNow.AddHours(4)
            };

            await _context.ServiceDetails.AddAsync(serviceDetail);
            await _context.SaveChangesAsync();

            return serviceDetail;
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromForm] ServiceUpdateDTO serviceUpdateDTO)
        {
            var barber = await _barberService.GetAsync(serviceUpdateDTO.BarberId);

            List<ServiceJSONObj> servicesJSON = JsonConvert.DeserializeObject<List<ServiceJSONObj>>(serviceUpdateDTO.Services);

            List<UserService> userServices = new();

            foreach (var serviceJSON in servicesJSON)
            {
                ServiceDetail detail = await CreateServiceDetailAsync(serviceJSON.Price);
                Service service = await GetAsync(serviceJSON.ServiceId);

                UserService userService = new()
                {
                    User = barber,
                    UserId = serviceUpdateDTO.BarberId,
                    Service = service,
                    ServiceId = service.Id,
                    ServiceDetailId = detail.Id,
                    ServiceDetail = detail
                };

                userServices.Add(userService);
            }

            barber.UserServices.Clear();
            await _context.UserServices.AddRangeAsync(userServices);
            await _context.SaveChangesAsync();

            return Ok(servicesJSON);
        }
    }

    class ServiceJSONObj
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public ServiceJSONObj()
        {
            Name = default!;
        }
    }
}
