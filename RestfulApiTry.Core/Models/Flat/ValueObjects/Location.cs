using RestFulApiTry.Application.Helpers;

namespace RestfulApiTry.Core.Models.Flat.ValueObjects;

public class Location : ValueObject
{
    private string city { get; }

    private Location(string city)
    {
        this.city = city;
    }

    public static Result<Location> Create(string city)
    {
        if (string.IsNullOrEmpty(city))
        {
            return Result<Location>.Failure("City cannot be null or empty");
        }

        var location = new Location(city);
        
        return Result<Location>.Success(location);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return city;
    }
}