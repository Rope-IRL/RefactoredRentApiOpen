using Microsoft.IdentityModel.Tokens;
using RestfulApiTry.Core.Models.LandlordInformation.ValueObjects;
using RestFulApiTry.Application.Helpers;

namespace RestfulApiTry.Core.Models.LandlordInformation
{
    public class LandlordInformation
    {
        public const int ALLOWED_START_AGE = 18;
        public const int ALLOWED_END_AGE = 130;

        public int Id { get; } = 0;
        public string Name { get; } = string.Empty;
        public string Surname { get; } = string.Empty;
        public int Age { get; } = 0;
        public PhoneNumber phoneNumber { get; }
        public decimal? Score { get; } = 0;

        private LandlordInformation(int id, string name, string surname, int age, PhoneNumber phoneNumber, decimal? score)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.phoneNumber = phoneNumber;
            this.Score = score;
        }

        public static Result<LandlordInformation> Create(int id, string name, string surname, int age, 
            PhoneNumber phoneNumber, decimal? score) 
        {
            if (name.IsNullOrEmpty() || surname.IsNullOrEmpty())
            {
                return Result<LandlordInformation>.Failure("Name can't be empty");
            }

            if(age < ALLOWED_START_AGE || age > ALLOWED_END_AGE)
            {
                return Result<LandlordInformation>.Failure("Age has to be in range between 18 and 130");
            }

            var landlordInformation = new LandlordInformation(id, name, surname, age, phoneNumber, score);

            return Result<LandlordInformation>.Success(landlordInformation);

        }

    }
}
