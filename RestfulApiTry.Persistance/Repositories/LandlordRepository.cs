using Microsoft.EntityFrameworkCore;
using RestFulApiTry.Application.Helpers;
using RestfulApiTry.Core.Models.Landlord;
using RestfulApiTry.Core.Repositories;
using RestfulApiTry.Persistence;

namespace RestfulApiTry.Persistence.Repositories
{
    public class LandlordRepository(RentDbContext dbContext): ILandlordRepository
    {
        public async Task<Result<Landlord>> GetLandlordAsync(int id, CancellationToken token)
        {
            var landlordModel = await dbContext.Landlords.FirstOrDefaultAsync(landlordModel =>  landlordModel.Id == id, token);

            var landlordResult = Landlord.Create(landlordModel.Id, landlordModel.Login, landlordModel.HashedPassword);
            
            return landlordResult;
        }
    }
}
