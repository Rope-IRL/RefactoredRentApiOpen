using RestfulApiTry.Core.Models.Landlord;
using RestfulApiTry.Persistence.Models;
using RestFulApiTry.Application.DTO;
using RestFulApiTry.Application.DTO.LandlordDTOS;
using RestFulApiTry.Application.Helpers;


namespace RestFulApiTry.Application.Mappers
{
    public class LandlordMapper
    {

        public static Result<Landlord> FromDtoToDomain(LandlordDto landlordDto)
        {
            var landlordResult = Landlord.Create(landlordDto.Id, landlordDto.Login, landlordDto.HashedPassword);

            if (!landlordResult.IsSuccess)
            {
                return Result<Landlord>.Failure("Failed to do operation with landlord");
            }
            return Result<Landlord>.Success(landlordResult.Value);
        }

        public static Result<LandlordDto> FromDomainToDto(Landlord landlord)
        {
            var landlordDto = new LandlordDto(landlord.Id, landlord.Login, landlord.HashedPassword);
            
            return Result<LandlordDto>.Success(landlordDto);
        }
    }
}
