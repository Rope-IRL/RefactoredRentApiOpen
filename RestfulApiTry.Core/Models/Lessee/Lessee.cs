using Microsoft.Identity.Client;
using RestFulApiTry.Application.Helpers;

namespace RestfulApiTry.Core.Models.Lessee
{
    public class Lessee
    {
        public int Id { get; } = 0;

        public string Login { get; } = string.Empty;

        public string HashedPassword { get; } = string.Empty;

        private Lessee(int id, string login, string hashedPassword)
        {
            Id = id;
            Login = login;
            HashedPassword = hashedPassword;
        }

        public static Result<Lessee> Create(int id, string login, string hashedPassword)
        {
            if(string.IsNullOrWhiteSpace(login))
            {
                return Result<Lessee>.Failure("Username is required");
            }

            if (string.IsNullOrWhiteSpace(hashedPassword))
            {
                return Result<Lessee>.Failure("Password is required");
            }

            var lessee = new Lessee(id, login, hashedPassword);
            return Result<Lessee>.Success(lessee);
        }
    }
}
