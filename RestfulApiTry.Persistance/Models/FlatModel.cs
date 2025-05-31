using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestfulApiTry.Persistence.Models;

public class FlatModel
{
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Header { get; set; } 
    
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    
    [DefaultValue(0)]
    [Precision(3,1)]
    public decimal? AverageMark { get; set; }
    
    [MaxLength(30)]
    [Required]
    public string City { get; set; }
    
    [DefaultValue(0)]
    public short NumberOfRooms { get; set; }
    
    [DefaultValue(0)]
    public short NumberOfFloors { get; set; }
    
    [DefaultValue(0)]
    public bool IsBathRoomAvailable { get; set; }

    [DefaultValue(0)]
    public bool IsWiFiAvailable { get; set; }

    [Precision(7,3)]
    public decimal CostPerDay { get; set; }
    
    [ForeignKey("LandlordId")] 
    public int LandlordId { get; set; }
    public LandlordModel? LandlordModel { get; set; }
}