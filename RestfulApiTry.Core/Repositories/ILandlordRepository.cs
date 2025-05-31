using RestFulApiTry.Application.Helpers;
using RestfulApiTry.Core.Models.Landlord;

namespace RestfulApiTry.Core.Repositories;

public interface ILandlordRepository
{
    public Task<Result<Landlord>> GetLandlordAsync(int id, CancellationToken token);
}