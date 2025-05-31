namespace RestFulApiTry.Application.DTO.LandlordDTOS
{
    public class LandlordDto
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string HashedPassword { get; set; }

        public LandlordDto(int id, string login, string password) 
        {
            Id = id;
            Login = login;
            HashedPassword = password;
        }

    }
}
