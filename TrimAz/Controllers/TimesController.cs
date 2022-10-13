using Business.Services;
using Entity.DTO.Time;
using Exceptions.EntityExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrimAz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimesController : ControllerBase
    {
        private readonly ITimeService _timeService;

        public TimesController(ITimeService timeService)
        {
            _timeService = timeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var datas = await _timeService.GetAllAsync();

                List<TimeGetDTO> timeList = new();

                foreach (var data in datas)
                {
                    TimeGetDTO time = new()
                    {
                        Id = data.Id,
                        Range = data.Range
                    };

                    timeList.Add(time);
                }
                return Ok(timeList);
            }
            catch (EntityCouldNotFoundException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
