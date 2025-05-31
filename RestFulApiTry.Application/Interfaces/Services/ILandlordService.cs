using RestFulApiTry.Application.DTO.LandlordDTOS;
using RestFulApiTry.Application.Helpers;

namespace RestFulApiTry.Application.Interfaces.Services
{
    public interface ILandlordService
    {
        Task<Result<int>> CreateLandlordAsync(string landlordLogin,string landlordPassword, CancellationToken token);
        Task<Result<LandlordDto>> GetLandlordByIdAsync(int id, CancellationToken token);

    }
}
