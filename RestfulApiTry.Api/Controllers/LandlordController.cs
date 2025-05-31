using Microsoft.AspNetCore.Mvc;
using RestFulApiTry.Application.DTO.LandlordDTOS;
using RestFulApiTry.Application.Interfaces.Services;

namespace RestfulApiTry.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LandlordController(ILandlordService landlordService): Controller
    {
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LandlordDto>> GetById(int id, CancellationToken token)
        {
            var landlordResult = await landlordService.GetLandlordByIdAsync(id, token);

            if (!landlordResult.IsSuccess)
            {
                return NotFound(landlordResult.Error);
            }

            return Ok(landlordResult.Value);
        }
        
    }
}
