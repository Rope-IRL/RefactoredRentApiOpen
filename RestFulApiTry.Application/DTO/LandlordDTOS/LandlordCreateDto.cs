namespace RestFulApiTry.Application.DTO.LandlordDTOS;

public class LandlordCreateDto
{
    public string Login { get; set; }
    public string HashedPassword { get; set; }

    public LandlordCreateDto(string login, string password) 
    {
        Login = login;
        HashedPassword = password;
    }
    
}