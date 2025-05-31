using RestFulApiTry.Application.Helpers;

namespace RestfulApiTry.Core.Models.Landlord
{
    public class Landlord
    {
        public int Id { get; } = 0;

        public string Login { get; } = string.Empty;

        public string HashedPassword { get; } = string.Empty;

        private Landlord(int id, string login, string hashedPassword)
        {
            Id = id;
            Login = login;
            HashedPassword = hashedPassword;
        }

        public static Result<Landlord> Create(int id, string login, string hashedPassword)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                return Result<Landlord>.Failure("Username is required");
            }

            if (string.IsNullOrWhiteSpace(hashedPassword))
            {
                return Result<Landlord>.Failure("Password is required");
            }

            var landlord = new Landlord(id, login, hashedPassword);
            return Result<Landlord>.Success(landlord);
        }
    }
}
