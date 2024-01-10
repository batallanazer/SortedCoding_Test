using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sorted.DataContract.Response;
using Sorted.Service;

namespace SortedCodingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallService _rainfallService;
        public RainfallController(IRainfallService rainfallService)
        {
            _rainfallService = rainfallService;
        }
        [HttpGet("{stationId}")]
        public async Task<IActionResult> Get(int stationId)
        {
            try
            {
                var result = await _rainfallService.Get(stationId);
                return result == null ? NotFound() : Ok(result);
            }catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
