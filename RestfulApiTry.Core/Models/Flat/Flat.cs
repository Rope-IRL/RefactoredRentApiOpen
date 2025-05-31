using System.Runtime.InteropServices;
using Microsoft.IdentityModel.Tokens;
using RestFulApiTry.Application.Helpers;
using RestfulApiTry.Core.Models.Flat.ValueObjects;

namespace RestfulApiTry.Core.Models.Flat;

public class Flat
{
    public int Id { get; } = 0;
    
    public string Header { get; } = string.Empty;
    
    public string Description { get; } = string.Empty;
    
    public decimal? AverageMark { get; }
    
    public Location Location { get; }
    
    public short NumberOfRooms { get; }
    
    public short NumberOfFloors { get; }
    
    public bool IsBathRoomAvailable { get; }
    
    public bool IsWiFiAvailable { get; }
    
    public decimal CostPerDay { get; }

    private Flat(int id, string header, string description, decimal? averageMark,
        Location location, short numberOfRooms, short numberOfFloors,
        bool isBathRoomAvailable, bool isWiFiAvailable, decimal costPerDay)
    {
        Id = id;
        Header = header;
        Description = description;
        AverageMark = averageMark;
        Location = location;
        NumberOfRooms = numberOfRooms;
        NumberOfFloors = numberOfFloors;
        IsBathRoomAvailable = isBathRoomAvailable;
        IsWiFiAvailable = isWiFiAvailable;
        CostPerDay = costPerDay;
    }

    public static Result<Flat> Create(int id, string header, string description, decimal? averageMark,
        string city, short numberOfRooms, short numberOfFloors,
        bool isBathRoomAvailable, bool isWiFiAvailable, decimal costPerDay)
    {
        if (header.IsNullOrEmpty() || description.IsNullOrEmpty())
        {
            return Result<Flat>.Failure("Header and description are required");
        }

        var locationResult = Location.Create(city);

        if (!locationResult.IsSuccess)
        {
            return Result<Flat>.Failure(locationResult.Error);
        }

        var flat = new Flat(id, header, description, averageMark, locationResult.Value,
            numberOfRooms, numberOfFloors, isBathRoomAvailable, isWiFiAvailable, costPerDay); 
        
        return Result<Flat>.Success(flat);
    }
}