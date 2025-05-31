using Microsoft.IdentityModel.Tokens;
using RestfulApiTry.Core.Models.LesseeInformation.ValueObjects;
using RestFulApiTry.Application.Helpers;

namespace RestfulApiTry.Core.Models.LesseeInformation
{
    public class LesseeInformation
    {
        public const int ALLOWED_START_AGE = 18;
        public const int ALLOWED_END_AGE = 130;

        public int Id { get; } = 0;
        public string Name { get; } = string.Empty;
        public string Surname { get; } = string.Empty;
        public int Age { get; } = 0;
        public PhoneNumber phoneNumber { get; }
        public decimal? Score { get; } = 0;

        private LesseeInformation(int id, string name, string surname, int age, PhoneNumber phoneNumber, decimal? score)
        {
            this.Id = id;
            this.Name = name;
            this.Surname = surname;
            this.phoneNumber = phoneNumber;
            this.Score = score;
        }

        public static Result<LesseeInformation> Create(int id, string name, string surname, int age,
            PhoneNumber phoneNumber, decimal? score)
        {
            if (name.IsNullOrEmpty() || surname.IsNullOrEmpty())
            {
                return Result<LesseeInformation>.Failure("Name can't be empty");
            }

            if (age < ALLOWED_START_AGE || age > ALLOWED_END_AGE)
            {
                return Result<LesseeInformation>.Failure("Age has to be in range between 18 and 130");
            }

            var landlordInformation = new LesseeInformation(id, name, surname, age, phoneNumber, score);

            return Result<LesseeInformation>.Success(landlordInformation);

        }
    }
}
