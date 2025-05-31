using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace RestfulApiTry.Persistence.Models;

public class LesseeInformationModel
{

    [Key] public int Id { get; set; }

    [Required] 
    [MaxLength(20)] 
    [DefaultValue("")]
    public string Name { get; set; }

    [Required] [MaxLength(25)]
    [DefaultValue("")]
    public string Surname { get; set; }

    [Required]
    [DefaultValue(18)]
    
    public int Age { get; set; }

    [Required] 
    [MaxLength(15)] 
    [DefaultValue("")]
    public string PhoneNumber { get; set; }

    [Precision(3, 1)] 
    [DefaultValue(0)] 
    public decimal Score { get; set; }

    [ForeignKey("LesseeId")]
    public int LesseeId { get; set; }
    public LesseeModel? LesseeModel { get; set; }

}