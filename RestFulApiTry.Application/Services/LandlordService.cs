using RestFulApiTry.Application.DTO.LandlordDTOS;
using RestFulApiTry.Application.Helpers;
using RestFulApiTry.Application.Interfaces.Services;
using RestFulApiTry.Application.Mappers;
using RestfulApiTry.Core.Repositories;

namespace RestFulApiTry.Application.Services
{
    public class LandlordService(ILandlordRepository repository) : ILandlordService
    {

        public Task<Result<int>> CreateLandlordAsync(string landlordLogin, string landlordPassword, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<LandlordDto>> GetLandlordByIdAsync(int id, CancellationToken token)
        {
            var landlordResult = await repository.GetLandlordAsync(id, token);

            if (!landlordResult.IsSuccess)
            {
                return Result<LandlordDto>.Failure("Failed to get landlord");
            }
            
            var landlordDtoResult = LandlordMapper.FromDomainToDto(landlordResult.Value);

            return landlordDtoResult;

        }
    }
}
